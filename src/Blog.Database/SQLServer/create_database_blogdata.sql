USE master;
GO

--Delete the BlogData database if it exists.
IF EXISTS(SELECT * from sys.databases WHERE name='BlogData')
BEGIN
    DROP DATABASE BlogData;
END

--Create a new database called BlogData.
CREATE DATABASE BlogData;
GO