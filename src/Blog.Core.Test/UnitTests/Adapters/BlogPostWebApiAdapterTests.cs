using Blog.Core.Test.Mocks;
using Blog.Core.Test.Stubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostWebApiAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIWebApiDataAccess _mockWebApiDataAccess;
        private readonly BlogPostWebApiAdapter _blogPostAdapter;

        public BlogPostWebApiAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockWebApiDataAccess = new MockIWebApiDataAccess();
            _blogPostAdapter = new BlogPostWebApiAdapter(_stubConfiguration, _mockWebApiDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogPostAdapter.Add(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void Delete_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogPostAdapter.Delete(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void DeleteByAuthorId_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogPostAdapter.DeleteAllByAuthorId(param_entity.AuthorId);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void Edit_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogPost() as BlogPost;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogPostAdapter.Edit(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void GetById_VerifySendRequestCalledAndExpectedBlogPostReturned()
        {
            var stub_entity = new StubBlogPost() as BlogPost;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_entity));
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_entity;
            var actual = _blogPostAdapter.GetById(stub_entity.PostId);
            _mockWebApiDataAccess.VerifySendRequestCalled();
            AssertBlogPostAreEqual(expected, actual);
        }

        [Fact]
        public void List_VerifySendRequestCalledAndExpectedListReturned()
        {
            var stub_entity = new StubBlogPost() as BlogPost;
            var stub_list = new List<BlogPost> { stub_entity };
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_list));
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_list;
            var actual = _blogPostAdapter.List();
            _mockWebApiDataAccess.VerifySendRequestCalled();
            AssertListOfBlogPostAreEqual(expected, actual);
        }

        [Fact]
        public void ListByAuthorId_VerifySendRequestCalledAndExpectedListReturned()
        {
            var stub_entity = new StubBlogPost() as BlogPost;
            var stub_list = new List<BlogPost> { stub_entity };
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_list));
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_list;
            var actual = _blogPostAdapter.ListByAuthorId(stub_entity.AuthorId);
            _mockWebApiDataAccess.VerifySendRequestCalled();
            AssertListOfBlogPostAreEqual(expected, actual);
        }

        private void AssertBlogPostAreEqual(BlogPost expected, BlogPost actual)
        {
            Assert.Equal(expected.AuthorId, actual.AuthorId);
            Assert.Equal(expected.PostBody, actual.PostBody);
            Assert.Equal(expected.PostId, actual.PostId);
            Assert.Equal(expected.PostTitle, actual.PostTitle);
            Assert.Equal(expected.TimeCreated, actual.TimeCreated);
            Assert.Equal(expected.TimeLastModified, actual.TimeLastModified);
        }

        private void AssertListOfBlogPostAreEqual(List<BlogPost> expected, List<BlogPost> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                AssertBlogPostAreEqual(expected[i], actual[i]);
        }
    }
}
