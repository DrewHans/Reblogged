USE BlogData;
GO

--Delete the BlogPost table if it exists.
DROP TABLE IF EXISTS dbo.BlogPost

--Create a new table called BlogPost.
CREATE TABLE dbo.BlogPost
   (PostId NChar PRIMARY KEY NOT NULL,
    AuthorId NChar NOT NULL,
    PostBody NChar NULL,
    PostTitle NChar NULL,
    TimeCreated DateTime NOT NULL,
    TimeLastModified DateTime NOT NULL)
GO