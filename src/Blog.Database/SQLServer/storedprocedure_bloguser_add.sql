USE BlogData;
GO
CREATE PROCEDURE BlogData.AddNewBlogUser
    @Permissions NVarChar,
    @TimeRegistered DateTime,
    @UserId NChar,
    @UserName NChar
AS
    SET NOCOUNT OFF;
    INSERT INTO BlogUser (
    	Permissions,
    	TimeRegistered,
    	UserId,
    	UserName)
    VALUES (
    	@Permissions,
    	@TimeRegistered,
    	@UserId,
    	@UserName);
GO
