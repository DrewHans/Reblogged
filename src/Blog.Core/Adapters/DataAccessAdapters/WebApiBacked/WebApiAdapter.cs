using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Blog.Core
{
    public abstract class WebApiAdapter
    {
        protected readonly IConfiguration _configuration;
        protected readonly IWebApiDataAccess _webApiDataAccess;

        public WebApiAdapter(IConfiguration configuration, IWebApiDataAccess webApiDataAccess)
        {
            _configuration = configuration;
            _webApiDataAccess = webApiDataAccess;
        }

        protected AuthenticationHeaderValue BuildAuthHeader()
        {
            var authscheme = _configuration[KeyChain.WebApiDataAccess_AuthScheme];
            var authtoken = _configuration[KeyChain.WebApiDataAccess_AuthToken];
            return new AuthenticationHeaderValue(authscheme, authtoken);
        }

        public HttpRequestMessage BuildHttpRequestMessage(Uri requestUri,
            HttpMethod httpMethod, string content, AuthenticationHeaderValue authHeader)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = requestUri;
            request.Method = httpMethod;
            request.Content = new StringContent(content);
            request.Headers.Authorization = authHeader;
            return request;
        }

        protected Uri BuildUri(string configKey_webapi_path, string query = null)
        {
            var uriBuilder = new UriBuilder();
            uriBuilder.Scheme = _configuration[KeyChain.WebApiDataAccess_UriScheme];
            uriBuilder.Host = _configuration[KeyChain.WebApiDataAccess_UriHost];
            uriBuilder.Path = _configuration[configKey_webapi_path];
            uriBuilder.Port = int.Parse(_configuration[KeyChain.WebApiDataAccess_UriPort]);
            if (string.IsNullOrEmpty(query) == false)
                uriBuilder.Query = query;
            return uriBuilder.Uri;
        }
    }
}