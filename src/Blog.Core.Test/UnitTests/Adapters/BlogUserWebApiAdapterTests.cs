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
        public void Add_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubWebApiDataAccess = new StubIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, stubWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            stubWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Add(param_entity);
        }

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
        public void Delete_Returns()
        {
            var fakeConfig = MakeFakeConfig();
            var stubWebApiDataAccess = new StubIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, stubWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            stubWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Delete(param_entity);
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
        public void Edit_Return()
        {
            var fakeConfig = MakeFakeConfig();
            var stubWebApiDataAccess = new StubIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, stubWebApiDataAccess);
            var param_entity = new BlogUserFactory().Create();
            stubWebApiDataAccess.StubSendRequest(MakeHttpResponseMessage(HttpStatusCode.OK));

            webApiAdapter.Edit(param_entity);
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
        public void GetById_ReturnsExpectedBlogUser()
        {
            var fakeConfig = MakeFakeConfig();
            var stubWebApiDataAccess = new StubIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, stubWebApiDataAccess);
            var param_id = new BlogUserFactory().Create().UserId;
            var expected = new BlogUserFactory().Create();
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected));
            stubWebApiDataAccess.StubSendRequest(stub_response);

            var actual = webApiAdapter.GetById(param_id);

            AssertBlogUserAreEqual(expected, actual);
        }

        [Fact]
        public void GetById_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var param_id = new BlogUserFactory().Create().UserId;
            var stub_expectedBlogUser = new BlogUserFactory().Create();
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_expectedBlogUser));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            webApiAdapter.GetById(param_id);

            mockWebApiDataAccess.VerifySendRequestCalled(1);
        }

        [Fact]
        public void List_ReturnsExpectedList()
        {
            var fakeConfig = MakeFakeConfig();
            var stubWebApiDataAccess = new StubIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, stubWebApiDataAccess);
            var stub_entity = new BlogUserFactory().Create();
            var expected = new List<BlogUser> { stub_entity };
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(expected));
            stubWebApiDataAccess.StubSendRequest(stub_response);

            var actual = webApiAdapter.List();

            AssertListOfBlogUserAreEqual(expected, actual);
        }

        [Fact]
        public void List_VerifySendRequestCalled()
        {
            var fakeConfig = MakeFakeConfig();
            var mockWebApiDataAccess = new MockIWebApiDataAccess();
            var webApiAdapter = new BlogUserWebApiAdapter(fakeConfig, mockWebApiDataAccess);
            var stub_entity = new BlogUserFactory().Create();
            var stub_list = new List<BlogUser> { stub_entity };
            var stub_response = MakeHttpResponseMessage(HttpStatusCode.OK);
            stub_response.Content = new StringContent(JsonConvert.SerializeObject(stub_list));
            mockWebApiDataAccess.StubSendRequest(stub_response);

            webApiAdapter.List();

            mockWebApiDataAccess.VerifySendRequestCalled(1);
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
