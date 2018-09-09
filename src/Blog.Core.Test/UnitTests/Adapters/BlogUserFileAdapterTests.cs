using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserFileAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIFileDataAccess<BlogUser> _mockFileDataAccess;
        private readonly BlogUserFileAdapter _blogUserAdapter;

        public BlogUserFileAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockFileDataAccess = new MockIFileDataAccess<BlogUser>();
            _blogUserAdapter = new BlogUserFileAdapter(_stubConfiguration, _mockFileDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifyWriteToDatabaseCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var expected_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            _blogUserAdapter.Add(param_entity);
            _mockFileDataAccess.VerifyWriteToDatabase(expected_filePath, param_entity);
        }

        [Fact]
        public void Delete_VerifyReadDatabaseAndOverwriteDatabaseCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_blogPost = new StubBlogUser() as BlogUser;
            stub_blogPost.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { param_entity, stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogUser> { stub_blogPost };
            _blogUserAdapter.Delete(param_entity);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            _mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDB_filePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void Edit_VerifyReadDatabaseAndOverwriteDatabaseCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_blogPost = new StubBlogUser() as BlogUser;
            stub_blogPost.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { param_entity, stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            param_entity.UserName = "This is an edited UserName!";
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogUser> { stub_blogPost, param_entity };
            _blogUserAdapter.Edit(param_entity);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            _mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDB_filePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void GetById_VerifyReadDatabaseCalledAndExpectedBlogUserReturned()
        {
            var stub_blogPost1 = new StubBlogUser() as BlogUser;
            var stub_blogPost2 = new StubBlogUser() as BlogUser;
            stub_blogPost2.UserId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogUser> { stub_blogPost1, stub_blogPost2 };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected = stub_blogPost2;
            var actual = _blogUserAdapter.GetById(stub_blogPost2.UserId);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_VerifyReadDatabaseCalledAndExpectedListReturned()
        {
            var stub_blogPost = new StubBlogUser() as BlogUser;
            var stub_list = new List<BlogUser> { stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogUser_DatabasePath];
            var expected = stub_list;
            var actual = _blogUserAdapter.List();
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            Assert.Equal(expected, actual);
        }
    }
}
