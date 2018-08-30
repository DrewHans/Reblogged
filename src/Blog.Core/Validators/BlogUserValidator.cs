using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserValidator : IBlogUserValidator
    {
        public bool IsValidBlogUser(BlogUser blogUser)
        {
            return IsValidPermissions(blogUser.Permissions)
                && IsValidTimeRegistered(blogUser.TimeRegistered)
                && IsValidUserId(blogUser.UserId)
                && IsValidUserName(blogUser.UserName);
        }

        public bool IsValidPermissions(List<string> permissions)
        {
            if (permissions == null)
                return false;
            foreach (var permission in permissions)
                if (string.IsNullOrEmpty(permission))
                    return false;
            return true;
        }

        public bool IsValidTimeRegistered(DateTime timeRegistered)
        {
            return true;
        }

        public bool IsValidUserId(Guid userId)
        {
            return true;
        }

        public bool IsValidUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            return true;
        }
    }
}