using System;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserValidatorTests
    {
        [Fact]
        public void ValidateBlogUser_ValidBlogUser_Returns()
        {
            var validator = new BlogUserValidator();
            var param_blogUser = new BlogUserFactory().Create();
            validator.ValidateBlogUser(param_blogUser);
        }

        [Fact]
        public void ValidateBlogUser_NullBlogUser_ThrowsException()
        {
            var validator = new BlogUserValidator();
            BlogUser param_blogUser = null;
            Assert.Throws<ArgumentNullException>(
                () => validator.ValidateBlogUser(param_blogUser));
        }

        [Fact]
        public void ValidateBlogUser_PermissionsIsNull_ThrowsException()
        {
            var validator = new BlogUserValidator();
            var param_blogUser = new BlogUserFactory().Create();
            param_blogUser.Permissions = null;
            Assert.Throws<ArgumentNullException>(
                () => validator.ValidateBlogUser(param_blogUser));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogUser_PermissionsElementIsInvalid_ThrowsException(string invalidValue)
        {
            var validator = new BlogUserValidator();
            var param_blogUser = new BlogUserFactory().Create();
            param_blogUser.Permissions.Add(invalidValue);
            Assert.Throws<ArgumentException>(
                () => validator.ValidateBlogUser(param_blogUser));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateBlogUser_UserNameIsInvalid_ThrowsException(string invalidValue)
        {
            var validator = new BlogUserValidator();
            var param_blogUser = new BlogUserFactory().Create();
            param_blogUser.UserName = invalidValue;
            Assert.Throws<ArgumentException>(
                () => validator.ValidateBlogUser(param_blogUser));
        }
    }
}