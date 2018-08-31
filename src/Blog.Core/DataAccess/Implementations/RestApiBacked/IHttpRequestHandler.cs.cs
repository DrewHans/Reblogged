using System.Threading.Tasks;

namespace Blog.Core
{
    public interface IHttpRequestHandler
    { 
        string GetRequest(string uri);
        Task<string> GetRequestAsync(string uri);
        string NonGetRequest(string uri, string data, string contentType, string method);
        Task<string> NonGetRequestAsync(string uri, string data, string contentType, string method);
    }
}