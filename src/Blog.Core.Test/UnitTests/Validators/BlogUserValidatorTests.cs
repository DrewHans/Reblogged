using Blog.Core.Test.Stubs;
using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserValidatorTests : IDisposable
    {
        private readonly BlogUserValidator _blogUserValidator;

        public BlogUserValidatorTests()
        {
            _blogUserValidator = new BlogUserValidator();
        }

        public void Dispose() { }

        [Fact]
        public void ValidateBlogUser_ValidBlogUser_Returns()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            _blogUserValidator.ValidateBlogUser(param_blogUser);
        }

        [Fact]
        public void ValidateBlogUser_NullBlogUser_ThrowsException()
        {
            BlogUser param_blogUser = null;
            Assert.Throws<ArgumentNullException>(
                () => _blogUserValidator.ValidateBlogUser(param_blogUser));
        }

        [Fact]
        public void ValidateBlogUser_PermissionsIsNull_ThrowsException()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            param_blogUser.Permissions = null;
            Assert.Throws<ArgumentNullException>(
                () => _blogUserValidator.ValidateBlogUser(param_blogUser));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogUser_PermissionsElementIsInvalid_ThrowsException(string invalidValue)
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            param_blogUser.Permissions.Add(invalidValue);
            Assert.Throws<ArgumentException>(
                () => _blogUserValidator.ValidateBlogUser(param_blogUser));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogUser_UserNameIsInvalid_ThrowsException(string invalidValue)
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            param_blogUser.UserName = invalidValue;
            Assert.Throws<ArgumentException>(
                () => _blogUserValidator.ValidateBlogUser(param_blogUser));
        }
    }
}