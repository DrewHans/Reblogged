USE BlogData;
GO
CREATE PROCEDURE BlogData.AddNewBlogPost
    @AuthorId NChar,
    @PostBody NChar,
    @PostId NChar,
    @PostTitle NChar,
    @TimeCreated DateTime,
    @TimeLastModified DateTime
AS
    SET NOCOUNT OFF;
    INSERT INTO BlogPost (
    	PostId,
    	AuthorId,
    	PostBody,
    	PostTitle,
    	TimeCreated,
    	TimeLastModified)
    VALUES (
    	@PostId,
    	@AuthorId,
    	@PostBody,
    	@PostTitle,
    	@TimeCreated,
    	@TimeLastModified);
GO
