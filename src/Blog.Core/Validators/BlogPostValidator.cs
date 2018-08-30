using System;

namespace Blog.Core
{
    public class BlogPostValidator : IBlogPostValidator
    {
        public bool IsValidAuthorId(Guid authorId)
        {
            return true;
        }

        public bool IsValidBlogPost(BlogPost blogPost)
        {
            return IsValidAuthorId(blogPost.AuthorId)
                && IsValidPostBody(blogPost.PostBody)
                && IsValidPostId(blogPost.PostId)
                && IsValidPostTitle(blogPost.PostTitle)
                && IsValidTimeCreated(blogPost.TimeCreated)
                && IsValidTimeLastModified(blogPost.TimeLastModified);
        }

        public bool IsValidPostBody(string postBody)
        {
            if (string.IsNullOrEmpty(postBody))
                return false;
            return true;
        }

        public bool IsValidPostId(Guid postId)
        {
            return true;
        }

        public bool IsValidPostTitle(string postTitle)
        {
            if (string.IsNullOrEmpty(postTitle))
                return false;
            return true;
        }

        public bool IsValidTimeCreated(DateTime timeCreated)
        {
            return true;
        }

        public bool IsValidTimeLastModified(DateTime timeLastModified)
        {
            return true;
        }
    }
}