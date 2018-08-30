using System;
using System.Collections.Generic;

namespace Blog.Core
{
    public class BlogUserValidator : IBlogUserValidator
    {
        public bool IsValidBlogUser(BlogUser blogUser)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPermissions(List<string> permissions)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTimeRegistered(DateTime timeRegistered)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUserId(Guid postId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}