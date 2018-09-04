using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            var authscheme = _configuration["webapi_authscheme"];
            var authtoken = _configuration["webapi_authtoken"];
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
            uriBuilder.Scheme = _configuration["webapi_scheme"];
            uriBuilder.Host = _configuration["webapi_host"];
            uriBuilder.Path = _configuration[configKey_webapi_path];
            uriBuilder.Port = int.Parse(_configuration["webapi_port"]);
            if (string.IsNullOrEmpty(query) == false)
                uriBuilder.Query = query;
            return uriBuilder.Uri;
        }
    }
}