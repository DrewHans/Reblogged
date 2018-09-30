USE BlogData;
GO
CREATE PROCEDURE BlogData.EditBlogPost
    @AuthorId NChar,
    @PostBody NChar,
    @PostId NChar,
    @PostTitle NChar,
    @TimeCreated DateTime,
    @TimeLastModified DateTime
AS
    SET NOCOUNT OFF;
    UPDATE BlogPost
    SET PostBody = @PostBody,
    	PostTitle = @PostTitle,
    	TimeCreated = @TimeCreated,
    	TimeLastModified = @TimeLastModified;
    WHERE PostId = @PostId AND AuthorId = @AuthorId;
GO
