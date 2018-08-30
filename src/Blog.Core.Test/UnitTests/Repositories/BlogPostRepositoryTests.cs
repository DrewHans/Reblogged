using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using System;
using System.Collections.Generic;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostRepositoryTests : IDisposable
    {
        private MockIBlogPostDataAccessAdapter _mockDataAccess;
        private readonly BlogPostRepository _blogPostRepository;

        public BlogPostRepositoryTests()
        {
            _mockDataAccess = new MockIBlogPostDataAccessAdapter();
            _blogPostRepository = new BlogPostRepository(_mockDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_ValidBlogPost_PassesParamToDataAccess()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            _blogPostRepository.Add(param_blogPost);
            _mockDataAccess.VerifyAdd(param_blogPost);
        }

        [Fact]
        public void Delete_ValidBlogPost_PassesParamToDataAccess()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            _blogPostRepository.Delete(param_blogPost);
            _mockDataAccess.VerifyDelete(param_blogPost);
        }

        [Fact]
        public void DeleteAllByAuthorId_ValidAuthorId_PassesParamToDataAccess()
        {
            var param_id = new StubBlogPost().AuthorId;
            _blogPostRepository.DeleteAllByAuthorId(param_id);
            _mockDataAccess.DeleteAllByAuthorId(param_id);
        }

        [Fact]
        public void Edit_ValidBlogPost_PassesParamToDataAccess()
        {
            var param_blogPost = new StubBlogPost() as BlogPost;
            _blogPostRepository.Edit(param_blogPost);
            _mockDataAccess.VerifyEdit(param_blogPost);
        }

        [Fact]
        public void GetById_ValidBlogPost_PassesParamToDataAccess()
        {
            var stub_blogPost = new StubBlogPost() as BlogPost;
            _mockDataAccess.StubGetById(stub_blogPost);
            var param_id = stub_blogPost.PostId;
            var expected = stub_blogPost;
            var actual = _blogPostRepository.GetById(param_id);
            Assert.Equal(expected, actual);
            _mockDataAccess.VerifyGetById(param_id);
        }

        [Fact]
        public void List_ValidBlogPost_PassesParamToDataAccess()
        {
            var stub_list = new List<BlogPost> { new StubBlogPost() as BlogPost };
            _mockDataAccess.StubList(stub_list);
            var expected = stub_list;
            var actual = _blogPostRepository.List();
            Assert.Equal(expected, actual);
            _mockDataAccess.VerifyList();
        }

        [Fact]
        public void ListByAuthorId_ValidAuthorId_PassesParamToDataAccess()
        {
            var stub_blogPost = new StubBlogPost() as BlogPost;
            var stub_list = new List<BlogPost> { stub_blogPost };
            _mockDataAccess.StubListByAuthorId(stub_list);
            var param_id = stub_blogPost.AuthorId;
            var expected = stub_list;
            var actual = _blogPostRepository.ListByAuthorId(param_id);
            Assert.Equal(expected, actual);
            _mockDataAccess.VerifyListByAuthorId(param_id);
        }
    }
}