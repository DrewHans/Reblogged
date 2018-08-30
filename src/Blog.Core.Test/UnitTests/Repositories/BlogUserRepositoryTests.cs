using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserRepositoryTests : IDisposable
    {
        private MockIBlogUserDataAccessAdapter _mockDataAccess;
        private readonly BlogUserRepository _blogUserRepository;

        public BlogUserRepositoryTests()
        {
            _mockDataAccess = new MockIBlogUserDataAccessAdapter();
            _blogUserRepository = new BlogUserRepository(_mockDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_ValidBlogUser_PassesParamToDataAccess()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            _blogUserRepository.Add(param_blogUser);
            _mockDataAccess.VerifyAdd(param_blogUser);
        }

        [Fact]
        public void Delete_ValidBlogUser_PassesParamToDataAccess()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            _blogUserRepository.Delete(param_blogUser);
            _mockDataAccess.VerifyDelete(param_blogUser);
        }

        [Fact]
        public void Edit_ValidBlogUser_PassesParamToDataAccess()
        {
            var param_blogUser = new StubBlogUser() as BlogUser;
            _blogUserRepository.Edit(param_blogUser);
            _mockDataAccess.VerifyEdit(param_blogUser);
        }

        [Fact]
        public void GetById_ValidBlogUser_PassesParamToDataAccess()
        {
            var stub_blogUser = new StubBlogUser() as BlogUser;
            _mockDataAccess.StubGetById(stub_blogUser);
            var param_id = stub_blogUser.UserId;
            var expected = stub_blogUser;
            var actual = _blogUserRepository.GetById(param_id);
            Assert.Equal(expected, actual);
            _mockDataAccess.VerifyGetById(param_id);
        }

        [Fact]
        public void List_ValidBlogUser_PassesParamToDataAccess()
        {
            var stub_list = new List<BlogUser> { new StubBlogUser() as BlogUser };
            _mockDataAccess.StubList(stub_list);
            var expected = stub_list;
            var actual = _blogUserRepository.List();
            Assert.Equal(expected, actual);
            _mockDataAccess.VerifyList();
        }
    }
}