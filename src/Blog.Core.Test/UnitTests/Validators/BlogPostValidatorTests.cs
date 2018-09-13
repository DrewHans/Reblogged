using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostValidatorTests
    {
        [Fact]
        public void ValidateBlogPost_ValidBlogPost_Returns()
        {
            var validator = new BlogPostValidator();
            var param_blogPost = new BlogPostFactory().Create();
            validator.ValidateBlogPost(param_blogPost);
        }

        [Fact]
        public void ValidateBlogPost_NullBlogPost_ThrowsException()
        {
            var validator = new BlogPostValidator();
            BlogPost param_blogPost = null;
            Assert.Throws<ArgumentNullException>(
                () => validator.ValidateBlogPost(param_blogPost));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogPost_PostBodyIsInvalid_ThrowsException(string invalidValue)
        {
            var validator = new BlogPostValidator();
            var param_blogPost = new BlogPostFactory().Create();
            param_blogPost.PostBody = invalidValue;
            Assert.Throws<ArgumentException>(
                () => validator.ValidateBlogPost(param_blogPost));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogPost_PostTitleIsInvalid_ThrowsException(string invalidValue)
        {
            var validator = new BlogPostValidator();
            var param_blogPost = new BlogPostFactory().Create();
            param_blogPost.PostTitle = invalidValue;
            Assert.Throws<ArgumentException>(
                () => validator.ValidateBlogPost(param_blogPost));
        }
    }
}