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
    public class BlogUserWebApiAdapterTests : IDisposable
    {
        private StubIConfiguration _stubConfiguration;
        private MockIWebApiDataAccess _mockWebApiDataAccess;
        private readonly BlogUserWebApiAdapter _blogUserAdapter;

        public BlogUserWebApiAdapterTests()
        {
            _stubConfiguration = new StubIConfiguration();
            _mockWebApiDataAccess = new MockIWebApiDataAccess();
            _blogUserAdapter = new BlogUserWebApiAdapter(_stubConfiguration, _mockWebApiDataAccess);
        }

        public void Dispose() { }

        [Fact]
        public void Add_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogUserAdapter.Add(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void Delete_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogUserAdapter.Delete(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void Edit_VerifySendRequestCalled()
        {
            var param_entity = new StubBlogUser() as BlogUser;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            _blogUserAdapter.Edit(param_entity);
            _mockWebApiDataAccess.VerifySendRequestCalled();
        }

        [Fact]
        public void GetById_VerifySendRequestCalledAndExpectedBlogUserReturned()
        {
            var stub_entity = new StubBlogUser() as BlogUser;
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_entity));
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_entity;
            var actual = _blogUserAdapter.GetById(stub_entity.UserId);
            _mockWebApiDataAccess.VerifySendRequestCalled();
            AssertBlogUserAreEqual(expected, actual);
        }

        [Fact]
        public void List_VerifySendRequestCalledAndExpectedListReturned()
        {
            var stub_entity = new StubBlogUser() as BlogUser;
            var stub_list = new List<BlogUser> { stub_entity };
            var stub_response = new StubHttpResponseMessage(HttpStatusCode.OK) as HttpResponseMessage;
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_list));
            _mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_list;
            var actual = _blogUserAdapter.List();
            _mockWebApiDataAccess.VerifySendRequestCalled();
            AssertListOfBlogUserAreEqual(expected, actual);
        }

        private void AssertBlogUserAreEqual(BlogUser expected, BlogUser actual)
        {
            Assert.Equal(expected.Permissions, actual.Permissions);
            Assert.Equal(expected.TimeRegistered, actual.TimeRegistered);
            Assert.Equal(expected.UserId, actual.UserId);
            Assert.Equal(expected.UserName, actual.UserName);
        }

        private void AssertListOfBlogUserAreEqual(List<BlogUser> expected, List<BlogUser> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                AssertBlogUserAreEqual(expected[i], actual[i]);
        }
    }
}
