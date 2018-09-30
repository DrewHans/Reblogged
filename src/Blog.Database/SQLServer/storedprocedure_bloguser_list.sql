USE BlogData;
GO
CREATE PROCEDURE BlogData.ListBlogUsers
AS
    SET NOCOUNT OFF;
    SELECT Permissions,
        TimeRegistered,
        UserId,
        UserName
    FROM BlogUser
    ORDER BY UserId;
GO
