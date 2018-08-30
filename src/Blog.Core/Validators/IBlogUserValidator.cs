using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public interface IBlogUserValidator
    {
        bool IsValidBlogUser(BlogUser blogUser);
        bool IsValidPermissions(List<string> permissions);
        bool IsValidTimeRegistered(DateTime timeRegistered);
        bool IsValidUserId(Guid postId);
        bool IsValidUserName(string userName);
    }
}