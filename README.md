# InsertCreator
Creates an Insert statement for each row of query results pasted in.  I built this as an easier way to transfer data between environments.  I can write a query in prod, copy the results (with header) and paste them into this app to create insert statements.  I can then do slight modifications to the insert statement and run it in the environment I want.

I put a place holder for table name since it can't be derived from the query results.  Maybe in the future I could past in a query and have it generate insert statements but that would require connection strings to various databases, etc.. 

Since the query results appear to only be separated by white space I do have a problem with fields containing spaces, my tool splits them into multiple values.  It doesn't take much time to correct but could be a pain with query results that have lots of longer text and date time fields

I have a check for zero padded numbers to be treated like strings but it also puts single quotes around decimal values that start with zero that I have to fix.
