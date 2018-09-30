USE BlogData;
GO
CREATE PROCEDURE BlogData.DeleteBlogUser
    @UserId NChar
AS
    SET NOCOUNT OFF;
    DELETE FROM BlogUser
    WHERE UserId = @UserId;
GO
