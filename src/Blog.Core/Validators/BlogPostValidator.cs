using System;

namespace Blog.Core
{
    public class BlogPostValidator : IBlogPostValidator
    {
        public void ValidateBlogPost(BlogPost blogPost)
        {
            if (blogPost == null)
                throw new ArgumentNullException("BlogPost cannot be null");
            ValidatePostBody(blogPost.PostBody);
            ValidatePostTitle(blogPost.PostTitle);
        }

        private void ValidatePostBody(string postBody)
        {
            if (string.IsNullOrEmpty(postBody))
                throw new ArgumentException("BlogPost.PostBody cannot be null or empty");
        }

        private void ValidatePostTitle(string postTitle)
        {
            if (string.IsNullOrEmpty(postTitle))
                throw new ArgumentException("BlogPost.PostBody cannot be null or empty");
        }
    }
}