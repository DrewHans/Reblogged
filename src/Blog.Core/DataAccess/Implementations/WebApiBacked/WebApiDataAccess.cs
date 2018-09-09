using System.Net.Http;

namespace Blog.Core
{
    public class WebApiDataAccess : IWebApiDataAccess
    {
        private readonly HttpClient _httpClient;

        public WebApiDataAccess()
            : this(new HttpClientHandler())
        { }

        public WebApiDataAccess(HttpMessageHandler handler)
        {
            _httpClient = new HttpClient(handler);
        }

        public HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            var response = _httpClient.SendAsync(request);
            return response.Result;
        }
    }
}