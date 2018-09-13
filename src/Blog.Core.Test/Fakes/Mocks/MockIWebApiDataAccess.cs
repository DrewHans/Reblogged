using Moq;
using System.Net.Http;

namespace Blog.Core.Test.Fakes
{
    public class MockIWebApiDataAccess : StubIWebApiDataAccess
    {
        public void VerifySendRequest(HttpRequestMessage request)
        {
            _mockIWebApiDataAccess
                .Verify(x => x.SendRequest(request));
        }

        public void VerifySendRequestCalled(int timesCalled)
        {
            _mockIWebApiDataAccess
                .Verify(x => x.SendRequest(It.IsAny<HttpRequestMessage>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifySendRequestNotCalled()
        {
            _mockIWebApiDataAccess
                .Verify(x => x.SendRequest(It.IsAny<HttpRequestMessage>()),
                    Times.Never());
        }
    }
}
