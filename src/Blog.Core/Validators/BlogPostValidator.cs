using System;

namespace Blog.Core
{
    public class BlogPostValidator : IBlogPostValidator
    {
        public bool IsValidAuthorId(Guid authorId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPostBody(string postBody)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPostId(Guid postId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPostTitle(string postTitle)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTimeCreated(DateTime timeCreated)
        {
            throw new NotImplementedException();
        }

        public bool IsValidTimeLastModified(DateTime timeLastModified)
        {
            throw new NotImplementedException();
        }
    }
}