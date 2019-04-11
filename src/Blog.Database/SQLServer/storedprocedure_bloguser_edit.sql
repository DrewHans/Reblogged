USE BlogData;
GO
CREATE PROCEDURE BlogData.EditBlogUser
    @Permissions NVarChar,
    @TimeRegistered DateTime,
    @UserId NChar,
    @UserName NChar
AS
    SET NOCOUNT OFF;
    UPDATE BlogUser
    SET Permissions = @Permissions,
    	TimeRegistered = @TimeRegistered,
    	UserName = @UserName;
    WHERE UserId = @UserId;
GO
