using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserValidator : IBlogUserValidator
    {
        public void ValidateBlogUser(BlogUser blogUser)
        {
            if (blogUser == null)
                throw new ArgumentNullException("BlogUser cannot be null");
            ValidatePermissions(blogUser.Permissions);
            ValidateUserName(blogUser.UserName);
        }

        private void ValidatePermissions(List<string> permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException("BlogUser.Permissions cannot be null");
            foreach (var permission in permissions)
                if (string.IsNullOrEmpty(permission))
                    throw new ArgumentException("BlogUser.Permissions elements cannot be null or empty");
        }

        private void ValidateUserName(string postName)
        {
            if (string.IsNullOrEmpty(postName))
                throw new ArgumentException("BlogUser.UserName cannot be null or empty");
        }
    }
}