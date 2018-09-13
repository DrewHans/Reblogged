using Blog.Core.Test.Fakes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Blog.Core.Test
{
    public class BlogUserWebApiAdapterTests
    {
        [Fact]
        public void Add_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Add(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void Delete_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Delete(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void Edit_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            mockWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Edit(param_entity);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void GetById_VerifySendRequestCalledAndExpectedBlogUserReturned()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_id = new BlogUserFactory().Create().UserId;
            var expected_return = new BlogUserFactory().Create();
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected_return));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            var actual_return = webApiAdapter.GetById(param_id);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
            AssertBlogUserAreEqual(expected_return, actual_return);
        }

        [Fact]
        public void List_VerifySendRequestCalledAndExpectedListReturned()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var expected_return = new List<BlogUser> { new BlogUserFactory().Create() };
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected_return));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            var actual_return = webApiAdapter.List();

            mockWebApiDataAccess.VerifySendRequestCalled(1);
            AssertListOfBlogUserAreEqual(expected_return, actual_return);
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
