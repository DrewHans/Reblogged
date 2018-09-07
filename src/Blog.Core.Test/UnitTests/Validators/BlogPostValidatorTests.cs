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
        public void IsValidAuthorId_ValidAuthorId_ReturnsTrue()
        {
            var param_authorId = new StubBlogPost().AuthorId;
            var expected = true;
            var actual = _blogPostValidator.IsValidAuthorId(param_authorId);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBlogPost_ValidBlogPost_ReturnsTrue()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            var expected = true;
            var actual = _blogPostValidator.IsValidBlogPost(param_blogPost);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBlogPost_PostBodyIsInvalid_ReturnsFalse()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            param_blogPost.PostBody = "";
            var expected = false;
            var actual = _blogPostValidator.IsValidBlogPost(param_blogPost);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBlogPost_PostTitleIsInvalid_ReturnsFalse()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            param_blogPost.PostTitle = "";
            var expected = false;
            var actual = _blogPostValidator.IsValidBlogPost(param_blogPost);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidPostBody_ValidPostBody_ReturnsTrue()
        {
            var param_postBody = new StubBlogPost().PostBody;
            var expected = true;
            var actual = _blogPostValidator.IsValidPostBody(param_postBody);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValidPostBody_NotValidPostBody_ReturnsFalse(string invalidValue)
        {
            string param_postBody = invalidValue;
            var expected = false;
            var actual = _blogPostValidator.IsValidPostBody(param_postBody);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidPostId_ValidPostId_ReturnsTrue()
        {
            var param_postId = new StubBlogPost().PostId;
            var expected = true;
            var actual = _blogPostValidator.IsValidPostId(param_postId);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidPostTitle_ValidPostTitle_ReturnsTrue()
        {
            var param_postTitle = new StubBlogPost().PostTitle;
            var expected = true;
            var actual = _blogPostValidator.IsValidPostTitle(param_postTitle);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValidPostTitle_NotValidPostTitle_ReturnsFalse(string invalidValue)
        {
            string param_postTitle = invalidValue;
            var expected = false;
            var actual = _blogPostValidator.IsValidPostTitle(param_postTitle);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidTimeCreated_ValidTimeCreated_ReturnsTrue()
        {
            var param_timeCreated = new StubBlogPost().TimeCreated;
            var expected = true;
            var actual = _blogPostValidator.IsValidTimeCreated(param_timeCreated);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidTimeLastModified_ValidTimeLastModified_ReturnsTrue()
        {
            var param_timeLastModified = new StubBlogPost().TimeLastModified;
            var expected = true;
            var actual = _blogPostValidator.IsValidTimeLastModified(param_timeLastModified);
            Assert.Equal(expected, actual);
        }
    }
}