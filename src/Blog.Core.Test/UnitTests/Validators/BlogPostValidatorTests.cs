using Blog.Core.Test.Stubs;
using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostValidatorTests : IDisposable
    {
        private readonly BlogPostValidator _blogPostValidator;

        public BlogPostValidatorTests()
        {
            _blogPostValidator = new BlogPostValidator();
        }

        public void Dispose() { }

        [Fact]
        public void ValidateBlogPost_ValidBlogPost_Returns()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            _blogPostValidator.ValidateBlogPost(param_blogPost);
        }

        [Fact]
        public void ValidateBlogPost_NullBlogPost_ThrowsException()
        {
            BlogPost param_blogPost = null;
            Assert.Throws<ArgumentNullException>(
                () => _blogPostValidator.ValidateBlogPost(param_blogPost));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogPost_PostBodyIsInvalid_ThrowsException(string invalidValue)
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            param_blogPost.PostBody = invalidValue;
            Assert.Throws<ArgumentException>(
                () => _blogPostValidator.ValidateBlogPost(param_blogPost));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogPost_PostTitleIsInvalid_ThrowsException(string invalidValue)
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            param_blogPost.PostTitle = invalidValue;
            Assert.Throws<ArgumentException>(
                () => _blogPostValidator.ValidateBlogPost(param_blogPost));
        }
    }
}