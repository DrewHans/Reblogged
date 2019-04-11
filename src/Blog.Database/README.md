# Blog.Database
This directory contains database related files for Reblogged.

### FileDB/
Contains the json files used for file-backed data access. In a real application you would want to store your data someplace more secure than in json files on a public GitHub repo but since I'm just doing this project for fun (and I want to avoid mucking up my file system with junk) I decided to put it here.

### SQLServer/
Contains Transact-SQL scripts I used when setting up SQLServer for SQLServer-backed data access. Note, SQL isn't my strong suite so these are super basic (just enough to get up and running). Also, in a real application you would probably want to hire a database specialist to optimize the stored procedures.
