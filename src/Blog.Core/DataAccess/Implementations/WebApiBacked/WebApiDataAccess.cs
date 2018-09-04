using System.Net.Http;

namespace Blog.Core
{
    public class WebApiDataAccess : IWebApiDataAccess
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            var response = _httpClient.SendAsync(request);
            return response.Result;
        }
    }
}