using Blog.Core.Test.Fakes;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserRepositoryTests
    {
        [Fact]
        public void Add_ValidBlogUser_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Add(param_blogUser);
        }

        [Fact]
        public void Add_ValidBlogUser_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var mockValidator = new MockIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, mockValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Add(param_blogUser);

            mockValidator.VerifyValidateBlogUser(param_blogUser);
        }

        [Fact]
        public void Add_ValidBlogUser_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(mockDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Add(param_blogUser);

            mockDataAccessAdapter.VerifyAdd(param_blogUser);
        }

        [Fact]
        public void Delete_ValidBlogUser_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Delete(param_blogUser);
        }

        [Fact]
        public void Delete_ValidBlogUser_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var mockValidator = new MockIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, mockValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Delete(param_blogUser);

            mockValidator.VerifyValidateBlogUser(param_blogUser);
        }

        [Fact]
        public void Delete_ValidBlogUser_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(mockDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Delete(param_blogUser);

            mockDataAccessAdapter.VerifyDelete(param_blogUser);
        }

        [Fact]
        public void Edit_ValidBlogUser_Returns()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Edit(param_blogUser);
        }

        [Fact]
        public void Edit_ValidBlogUser_VerifyValidator()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var mockValidator = new MockIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, mockValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Edit(param_blogUser);

            mockValidator.VerifyValidateBlogUser(param_blogUser);
        }

        [Fact]
        public void Edit_ValidBlogUser_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(mockDataAccessAdapter, stubValidator);
            var param_blogUser = new BlogUserFactory().Create();

            repository.Edit(param_blogUser);

            mockDataAccessAdapter.VerifyEdit(param_blogUser);
        }

        [Fact]
        public void GetById_ValidBlogUser_ReturnsExpectedBlogUser()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, stubValidator);
            var expected = new BlogUserFactory().Create();
            stubDataAccessAdapter.StubGetById(expected);
            var param_userId = expected.UserId;

            var actual = repository.GetById(param_userId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_ValidBlogUser_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(mockDataAccessAdapter, stubValidator);
            var param_userId = new BlogUserFactory().Create().UserId;

            repository.GetById(param_userId);

            mockDataAccessAdapter.VerifyGetById(param_userId);
        }

        [Fact]
        public void List_ValidBlogUser_ReturnsExpectedList()
        {
            var stubDataAccessAdapter = new StubIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(stubDataAccessAdapter, stubValidator);
            var expected = new List<BlogUser> { new BlogUserFactory().Create() };
            stubDataAccessAdapter.StubList(expected);

            var actual = repository.List();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_ValidBlogUser_VerifyDataAccessAdapter()
        {
            var mockDataAccessAdapter = new MockIBlogUserDataAccessAdapter();
            var stubValidator = new StubIBlogUserValidator();
            var repository = new BlogUserRepository(mockDataAccessAdapter, stubValidator);

            repository.List();

            mockDataAccessAdapter.VerifyList();
        }
    }
}
