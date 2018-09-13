using Blog.Core.Test.Fakes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogPostWebApiAdapterTests
    {
        [Fact]
        public void Add_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogPostFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Add(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void Delete_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogPostFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Delete(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void DeleteByAuthorId_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_id = new BlogPostFactory().Create().AuthorId;
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.DeleteAllByAuthorId(param_id);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void Edit_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogPostFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Edit(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void GetById_VerifySendRequestCalledAndExpectedBlogPostReturned()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_id = new BlogPostFactory().Create().PostId;
            var expected_return = new BlogPostFactory().Create();
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected_return));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            var actual_return = webApiAdapter.GetById(param_id);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
            AssertBlogPostAreEqual(expected_return, actual_return);
        }

        [Fact]
        public void List_VerifySendRequestCalledAndExpectedListReturned()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var expected_return = new List<BlogPost> { new BlogPostFactory().Create() };
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected_return));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            var actual_return = webApiAdapter.List();

            mockWebApiDataAccess.VerifySendRequestCalled(1);
            AssertListOfBlogPostAreEqual(expected_return, actual_return);
        }

        [Fact]
        public void ListByAuthorId_VerifySendRequestCalledAndExpectedListReturned()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogPostWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var stub_entity = new BlogPostFactory().Create();
            var stub_list = new List<BlogPost> { stub_entity };
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_list));
            mockWebApiDataAccess.StubSendRequest(stub_response);
            var expected = stub_list;

            var actual = webApiAdapter.ListByAuthorId(stub_entity.AuthorId);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
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

        private FakeIConfiguration MakeFakeConfig()
        {
            return new FakeIConfigurationFactory()
                .StubFakeDataForWebApiDataAccess()
                .Create();
        }

        private HttpResponseMessage MakeHttpResponseMessage(HttpStatusCode statusCode)
        {
            return new HttpResponseMessageFactory()
                .StubHttpResponseMessage(statusCode)
                .Create();
        }
    }
}
