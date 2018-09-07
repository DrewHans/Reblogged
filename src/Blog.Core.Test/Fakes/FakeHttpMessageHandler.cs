using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Core.Test.Fakes
{
    public interface IFakeHttpMessageHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly IFakeHttpMessageHandler _mockFakeHandler;

        public FakeHttpMessageHandler(IFakeHttpMessageHandler mockFakeHandler)
        {
            _mockFakeHandler = mockFakeHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _mockFakeHandler.SendAsync(request, cancellationToken);
        }
    }
}
