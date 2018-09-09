using Moq;
using System.Collections.Generic;
using System.Net.Http;

namespace Blog.Core.Test.Mocks
{
    public class MockIWebApiDataAccess : IWebApiDataAccess
    {
        private readonly Mock<IWebApiDataAccess> _mockIWebApiDataAccess;

        public MockIWebApiDataAccess()
        {
            _mockIWebApiDataAccess = new Mock<IWebApiDataAccess>();
        }

        public HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            return _mockIWebApiDataAccess.Object.SendRequest(request);
        }

        public MockIWebApiDataAccess StubSendRequest(HttpResponseMessage stub)
        {
            _mockIWebApiDataAccess
                .Setup(x => x.SendRequest(It.IsAny<HttpRequestMessage>()))
                .Returns(stub);
            return this;
        }

        public MockIWebApiDataAccess StubSendRequest(List<HttpResponseMessage> listOfStubs)
        {
            var stubSequence = _mockIWebApiDataAccess.SetupSequence(x =>
                x.SendRequest(It.IsAny<HttpRequestMessage>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public void VerifySendRequest(HttpRequestMessage request)
        {
            _mockIWebApiDataAccess.Verify(x => x.SendRequest(request));
        }

        public void VerifySendRequestCalled()
        {
            _mockIWebApiDataAccess.Verify(x => x.SendRequest(It.IsAny<HttpRequestMessage>()));
        }

        public void VerifySendRequestCalled(int timesCalled)
        {
            _mockIWebApiDataAccess.Verify(x => x.SendRequest(It.IsAny<HttpRequestMessage>()), 
                Times.Exactly(timesCalled));
        }

        public void VerifySendRequestNotCalled()
        {
            _mockIWebApiDataAccess.Verify(x => x.SendRequest(It.IsAny<HttpRequestMessage>()), 
                Times.Never());
        }
    }
}
