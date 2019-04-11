USE BlogData;
GO
CREATE PROCEDURE BlogData.DeleteBlogPost
    @PostId NChar
AS
    SET NOCOUNT OFF;
    DELETE FROM BlogPost
    WHERE PostId = @PostId;
GO
