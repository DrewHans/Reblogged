USE BlogData;
GO

--Delete the BlogUser table if it exists.
DROP TABLE IF EXISTS dbo.BlogUser

--Create a new table called BlogUser.
CREATE TABLE dbo.BlogUser
   (UserId NChar PRIMARY KEY NOT NULL,
    Permissions NVarChar NOT NULL,
    TimeRegistered DateTime NULL,
    UserName NChar NULL)
GO