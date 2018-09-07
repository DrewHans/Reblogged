using Blog.Core.Test.Fakes;
using Blog.Core.Test.Stubs;
using Blog.Core.Test.Mocks;
using Moq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Blog.Core.Test
{
    public class WebApiDataAccessTests : IDisposable
    {
        public WebApiDataAccessTests()
        {
            // Note:
            // Due to Microsoft nonsense this unit test class is a little different from
            //  the others. WebApiDataAccess relies on HttpClient, which is basically
            //  just a fancy manager for HttpMessageHandler and was designed to be
            //  reusable while consuming as little resources as possible.
            //  
            // If you dig into the code you will find that mocking HttpClient isn't really
            //  worth the effort since (1) it has no interface and (2) under the hood it uses
            //  HttpClientHandler, an implementation of HttpMessageHandler, to handle it's
            //  SendAsync calls which is the only method we really care about. So it seems
            //  like it would make sense to mock out HttpClientHandler, but doing that is it's
            //  own can of worms and there is a lot of extra functionality in there that we
            //  really don't care about (it's a partial class to boot, and I hate mocking those).
            //
            // So with all that in mind, I decided that it would best to create a fake
            //  implementation of HttpMessageHandler that could be initialized with a stubbed
            //  mock. This way, we can pass that fake implementation into WebApiDataAccess and
            //  use it to initialize HttpClient. This gives us the ability to stub responses
            //  and verify calls without having to refactor WebApiDataAccess to death or having
            //  to mock out HttpClientHandler.
            //
            // Unfortunately, taking this approach means that we have to expose our Moq method 
            //  setup and verify logic here in each unit test method... it's the price we have
            //  to pay for keeping WebApiDataAccess clean and keeping our Fake/Mock code small.
            //  Also, there's now this giant comment block here explaining why the unit test 
            //  code is different from the others... again, tradeoffs :)
        }

        public void Dispose() { }

        [Fact]
        public void Constructor_InitNewHttpClientHandler_InitializesWithoutError()
        {
            var webApiDataAccess = new WebApiDataAccess();
        }

        [Fact]
        public void SendAsync_ValidRequest_ReturnsExpectedResponse()
        {
            var param_request = new StubHttpRequestMessage() as HttpRequestMessage;
            var stub_response = new StubHttpResponseMessage() as HttpResponseMessage;
            var mockHandler = new Mock<IFakeHttpMessageHandler>();
            mockHandler.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(stub_response));
            var webApiDataAccess = new WebApiDataAccess(new FakeHttpMessageHandler(mockHandler.Object));
            var returned = webApiDataAccess.SendRequest(param_request);
            Assert.Equal(returned, stub_response);
        }
    }
}