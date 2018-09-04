using System.Net.Http;

namespace Blog.Core
{
    public interface IWebApiDataAccess
    {
        HttpResponseMessage SendRequest(HttpRequestMessage request);
    }
}