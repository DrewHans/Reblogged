using Moq;
using System.Net.Http;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIWebApiDataAccess : IWebApiDataAccess
    {
        private readonly Mock<IWebApiDataAccess> _mockIWebApiDataAccess;

        public FakeIWebApiDataAccess()
        {
            _mockIWebApiDataAccess = new Mock<IWebApiDataAccess>();
        }

        public HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            return _mockIWebApiDataAccess.Object.SendRequest(request);
        }
    }
}
