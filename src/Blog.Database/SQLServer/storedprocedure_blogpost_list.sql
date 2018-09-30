USE BlogData;
GO
CREATE PROCEDURE BlogData.ListBlogPosts
AS
    SET NOCOUNT OFF;
    SELECT AuthorId,
    	PostBody,
    	PostId,
        PostTitle,
    	TimeCreated,
    	TimeLastModified
    FROM BlogPost
    ORDER BY PostId;
GO
