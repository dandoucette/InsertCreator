using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsertCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SourceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            const string placeholder = "<<placeholder>>";
            var lines = SourceTextBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            string[] fields = lines[0].Split(null);

            string insert = $"INSERT INTO \\*tablename*\\ ({string.Join(", ", fields)}) VALUES ({placeholder})";
            var sb = new StringBuilder(); 

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(null);
                var fieldValues = new List<string>();

                foreach (var value in values)
                {
                    if(int.TryParse(value, out _) || double.TryParse(value, out _) || value == "NULL")
                    {
                        if (value.Length > 1 && value.StartsWith('0'))
                        {
                            fieldValues.Add($"'{value}'");
                        }
                        else
                        {
                            fieldValues.Add($"{value}");
                        }
                    }
                    else
                    {
                        fieldValues.Add($"'{value}'");
                    }
                }

                sb.AppendLine(insert.Replace(placeholder, string.Join(", ", fieldValues)));
            }

            InsertsTextBox.Text = sb.ToString();
        }
    }
}
