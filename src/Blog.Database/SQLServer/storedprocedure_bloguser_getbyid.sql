USE BlogData;
GO
CREATE PROCEDURE BlogData.GetBlogUser
    @UserId NChar
AS
    SET NOCOUNT OFF;
    SELECT Permissions,
        TimeRegistered,
        UserId,
        UserName
    FROM BlogUser
    WHERE UserId = @UserId;
GO
