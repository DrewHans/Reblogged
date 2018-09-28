using Blog.Core.Test.Fakes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostFileAdapterTests
    {
        [Fact]
        public void Add_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var param_entity = new BlogPostFactory().Create();

            fileAdapter.Add(param_entity);
        }

        [Fact]
        public void Add_VerifyDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogPostFactory().Create();
            var expectedfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];

            fileAdapter.Add(param_entity);

            mockFileDataAccess.VerifyWriteToDatabase(expectedfilePath, param_entity);
        }

        [Fact]
        public void Delete_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var param_entity = new BlogPostFactory().Create();
            var stub_blogPost = new BlogPostFactory().Create();
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            stubFileDataAccess.StubReadDatabase(stub_list);

            fileAdapter.Delete(param_entity);
        }

        [Fact]
        public void Delete_VerifyDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogPostFactory().Create();
            var stub_blogPost = new BlogPostFactory().Create();
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost };

            fileAdapter.Delete(param_entity);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDBfilePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void DeleteByAuthorId_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            stubFileDataAccess.StubReadDatabase(stub_list);

            fileAdapter.DeleteAllByAuthorId(stub_blogPost2.AuthorId);
        }

        [Fact]
        public void DeleteByAuthorId_VerifyDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost1 };

            fileAdapter.DeleteAllByAuthorId(stub_blogPost2.AuthorId);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDBfilePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void Edit_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var param_entity = new BlogPostFactory().Create();
            var stub_blogPost = new BlogPostFactory().Create();
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            stubFileDataAccess.StubReadDatabase(stub_list);

            fileAdapter.Edit(param_entity);
        }

        [Fact]
        public void Edit_VerifyDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var param_entity = new BlogPostFactory().Create();
            var stub_blogPost = new BlogPostFactory().Create();
            stub_blogPost.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { param_entity, stub_blogPost };
            mockFileDataAccess.StubReadDatabase(stub_list);
            param_entity.PostBody = "This is an edited PostBody!";
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];
            var expected_overwriteDB_newList = new List<BlogPost> { stub_blogPost, param_entity };

            fileAdapter.Edit(param_entity);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
            mockFileDataAccess.VerifyOverwriteDatabase(expected_overwriteDBfilePath, expected_overwriteDB_newList);
        }

        [Fact]
        public void GetById_ReturnsExpectedBlogPost()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            stubFileDataAccess.StubReadDatabase(stub_list);
            var expected = stub_blogPost2;

            var actual = fileAdapter.GetById(stub_blogPost2.PostId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_VerifyFileDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.PostId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];

            fileAdapter.GetById(stub_blogPost2.PostId);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
        }

        [Fact]
        public void List_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var stub_blogPost = new BlogPostFactory().Create();
            var stub_list = new List<BlogPost> { stub_blogPost };
            stubFileDataAccess.StubReadDatabase(stub_list);
            var expected = stub_list;

            var actual = fileAdapter.List();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void List_VerifyFileDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogPost = new BlogPostFactory().Create();
            var stub_list = new List<BlogPost> { stub_blogPost };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];

            fileAdapter.List();

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
        }

        [Fact]
        public void ListByAuthorId_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubFileDataAccess = new StubIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, stubFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            stubFileDataAccess.StubReadDatabase(stub_list);
            var expected = new List<BlogPost> { stub_blogPost2 };

            var actual = fileAdapter.ListByAuthorId(stub_blogPost2.AuthorId);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ListByAuthorId_VerifyFileDataAccess()
        {
            var fakeConfig = MakeFakeConfig();
            var mockFileDataAccess = new MockIFileDataAccess<BlogPost>();
            var fileAdapter = new BlogPostFileAdapter(fakeConfig, mockFileDataAccess);
            var stub_blogPost1 = new BlogPostFactory().Create();
            var stub_blogPost2 = new BlogPostFactory().Create();
            stub_blogPost2.AuthorId = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var stub_list = new List<BlogPost> { stub_blogPost1, stub_blogPost2 };
            mockFileDataAccess.StubReadDatabase(stub_list);
            var expected_readDBfilePath = fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath];

            fileAdapter.ListByAuthorId(stub_blogPost2.AuthorId);

            mockFileDataAccess.VerifyReadDatabase(expected_readDBfilePath);
        }

        private FakeIConfiguration MakeFakeConfig()
        {
            return new FakeIConfigurationFactory()
                .StubFakeDataForFileDataAccess()
                .Create();
        }
    }
}
