USE BlogData;
GO
CREATE PROCEDURE BlogData.DeleteAllBlogPostsByAuthor
    @AuthorId NChar
AS
    SET NOCOUNT OFF;
    DELETE FROM BlogPost
    WHERE AuthorId = @AuthorId;
GO
