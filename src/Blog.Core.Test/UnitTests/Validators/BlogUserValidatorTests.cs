using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
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
        public void IsValidBlogUser_ValidBlogUser_ReturnsTrue()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            var expected = true;
            var actual = _blogUserValidator.IsValidBlogUser(param_blogUser);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBlogUser_PermissionsIsInvalid_ReturnsFalse()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            param_blogUser.Permissions = null;
            var expected = false;
            var actual = _blogUserValidator.IsValidBlogUser(param_blogUser);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBlogUser_UserNameIsInvalid_ReturnsFalse()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            param_blogUser.UserName = "";
            var expected = false;
            var actual = _blogUserValidator.IsValidBlogUser(param_blogUser);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidPermissions_ValidPermissions_ReturnsTrue()
        {
            var param_permissions = new StubBlogUser().Permissions;
            var expected = true;
            var actual = _blogUserValidator.IsValidPermissions(param_permissions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidPermissions_PermissionsIsNull_ReturnsFalse()
        {
            List<string> param_permissions = null;
            var expected = false;
            var actual = _blogUserValidator.IsValidPermissions(param_permissions);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValidPermissions_PermissionsContainsNotValidElement_ReturnsFalse(string invalidValue)
        {
            var param_permissions = new StubBlogUser().Permissions;
            param_permissions[0] = invalidValue;
            var expected = false;
            var actual = _blogUserValidator.IsValidPermissions(param_permissions);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidUserId_ValidUserId_ReturnsTrue()
        {
            var param_userId = new StubBlogUser().UserId;
            var expected = true;
            var actual = _blogUserValidator.IsValidUserId(param_userId);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidTimeRegistered_ValidTimeRegistered_ReturnsTrue()
        {
            var param_timeRegistered = new StubBlogUser().TimeRegistered;
            var expected = true;
            var actual = _blogUserValidator.IsValidTimeRegistered(param_timeRegistered);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidUserName_ValidUserName_ReturnsTrue()
        {
            var param_userName = new StubBlogUser().UserName;
            var expected = true;
            var actual = _blogUserValidator.IsValidUserName(param_userName);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void IsValidUserName_NotValidUserName_ReturnsFalse(string invalidValue)
        {
            var param_userName = invalidValue;
            var expected = false;
            var actual = _blogUserValidator.IsValidUserName(param_userName);
            Assert.Equal(expected, actual);
        }
    }
}