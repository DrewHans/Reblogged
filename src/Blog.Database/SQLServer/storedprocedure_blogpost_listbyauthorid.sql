USE BlogData;
GO
CREATE PROCEDURE BlogData.ListBlogPostsByAuthor
	@AuthorId NChar
AS
    SET NOCOUNT OFF;
    SELECT AuthorId,
    	PostBody,
    	PostId,
        PostTitle,
    	TimeCreated,
    	TimeLastModified
    FROM BlogPost
    WHERE AuthorId = @AuthorId
    ORDER BY PostId;
GO
