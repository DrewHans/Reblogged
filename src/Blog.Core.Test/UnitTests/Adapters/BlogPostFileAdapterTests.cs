using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostFileAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIFileDataAccess<BlogPost> _mockFileDataAccess;
        private readonly BlogPostFileAdapter _blogPostAdapter;

        public BlogPostFileAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            _blogPostAdapter = new BlogPostFileAdapter(_stubConfiguration, _mockFileDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifyWriteToDatabaseCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var expected_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            _blogPostAdapter.Add(param_entity);
            _mockFileDataAccess.VerifyWriteToDatabase(expected_filePath, param_entity);
        }

        [Fact]
        public void Delete_VerifyReadDatabaseAndOverwriteDatabaseCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_blogPost = new StubBlogPost() as BlogPost;
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost };
            _blogPostAdapter.Delete(param_entity);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            _mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDB_filePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void DeleteByAuthorId_VerifyReadDatabaseAndOverwriteDatabaseCalled()
        {
            var stub_blogPost1 = new StubBlogPost() as BlogPost;
            var stub_blogPost2 = new StubBlogPost() as BlogPost;
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost1 };
            _blogPostAdapter.DeleteAllByAuthorId(stub_blogPost2.AuthorId);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            _mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDB_filePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void Edit_VerifyReadDatabaseAndOverwriteDatabaseCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_blogPost = new StubBlogPost() as BlogPost;
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            param_entity.PostBody = "This is an edited PostBody!";
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost, param_entity };
            _blogPostAdapter.Edit(param_entity);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            _mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDB_filePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void GetById_VerifyReadDatabaseCalledAndExpectedListReturned()
        {
            var stub_blogPost1 = new StubBlogPost() as BlogPost;
            var stub_blogPost2 = new StubBlogPost() as BlogPost;
            stub_blogPost2.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected = stub_blogPost2;
            var actual = _blogPostAdapter.GetById(stub_blogPost2.PostId);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_VerifyReadDatabaseCalledAndExpectedListReturned()
        {
            var stub_blogPost = new StubBlogPost() as BlogPost;
            var stub_list = new List<BlogPost> { stub_blogPost };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected = stub_list;
            var actual = _blogPostAdapter.List();
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ListByAuthorId_VerifyReadDatabaseCalledAndExpectedListReturned()
        {
            var stub_blogPost1 = new StubBlogPost() as BlogPost;
            var stub_blogPost2 = new StubBlogPost() as BlogPost;
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            _mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDB_filePath = _stubConfiguration[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected = new List<BlogPost> { stub_blogPost2 };
            var actual = _blogPostAdapter.ListByAuthorId(stub_blogPost2.AuthorId);
            _mockFileDataAccess.VerifyReadDatabase(expected_readDB_filePath);
            Assert.Equal(expected, actual);
        }
    }
}
