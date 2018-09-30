USE BlogData;
GO
CREATE PROCEDURE BlogData.GetBlogPost
    @PostId NChar
AS
    SET NOCOUNT OFF;
    SELECT AuthorId,
    	PostBody,
    	PostId,
        PostTitle,
    	TimeCreated,
    	TimeLastModified
    FROM BlogPost
    WHERE PostId = @PostId;
GO
