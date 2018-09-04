using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace Blog.Core
{
    public class BlogUserWebApiAdapter : WebApiAdapter, IBlogUserDataAccessAdapter
    {

        public BlogUserWebApiAdapter(IConfiguration configuration, IWebApiDataAccess webApiDataAccess)
            : base(configuration, webApiDataAccess) { }

        public void Add(BlogUser entity)
        {
            var configKey_webapi_path = "webapi_bloguser_add";
            var requestUri = this.BuildUri(configKey_webapi_path);
            var httpMethod = HttpMethod.Post;
            var content = JsonConvert.SerializeObject(entity);
            var authHeader = this.BuildAuthHeader();
            var request = this.BuildHttpRequestMessage(requestUri, httpMethod, content, authHeader);
            var response = _webApiDataAccess.SendRequest(request);
            response.EnsureSuccessStatusCode();
            request.Dispose();
            response.Dispose();
        }

        public void Delete(BlogUser entity)
        {
            var configKey_webapi_path = "webapi_bloguser_delete";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["userid"] = entity.UserId.ToString();
            var requestUri = this.BuildUri(configKey_webapi_path, query.ToString());
            var httpMethod = HttpMethod.Delete;
            var content = "";
            var authHeader = this.BuildAuthHeader();
            var request = this.BuildHttpRequestMessage(requestUri, httpMethod, content, authHeader);
            var response = _webApiDataAccess.SendRequest(request);
            response.EnsureSuccessStatusCode();
            request.Dispose();
            response.Dispose();
        }

        public void Edit(BlogUser entity)
        {
            var configKey_webapi_path = "webapi_bloguser_edit";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["userid"] = entity.UserId.ToString();
            var requestUri = this.BuildUri(configKey_webapi_path, query.ToString());
            var httpMethod = HttpMethod.Put;
            var content = JsonConvert.SerializeObject(entity);
            var authHeader = this.BuildAuthHeader();
            var request = this.BuildHttpRequestMessage(requestUri, httpMethod, content, authHeader);
            var response = _webApiDataAccess.SendRequest(request);
            response.EnsureSuccessStatusCode();
            request.Dispose();
            response.Dispose();
        }

        public BlogUser GetById(Guid id)
        {
            var configKey_webapi_path = "webapi_bloguser_getbyid";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["userid"] = id.ToString();
            var requestUri = this.BuildUri(configKey_webapi_path, query.ToString());
            var httpMethod = HttpMethod.Get;
            var content = "";
            var authHeader = this.BuildAuthHeader();
            var request = this.BuildHttpRequestMessage(requestUri, httpMethod, content, authHeader);
            var response = _webApiDataAccess.SendRequest(request);
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            request.Dispose();
            response.Dispose();
            return JsonConvert.DeserializeObject<BlogUser>(responseBody);
        }

        public List<BlogUser> List()
        {
            var configKey_webapi_path = "webapi_bloguser_list";
            var requestUri = this.BuildUri(configKey_webapi_path);
            var httpMethod = HttpMethod.Get;
            var content = "";
            var authHeader = this.BuildAuthHeader();
            var request = this.BuildHttpRequestMessage(requestUri, httpMethod, content, authHeader);
            var response = _webApiDataAccess.SendRequest(request);
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            request.Dispose();
            response.Dispose();
            return JsonConvert.DeserializeObject<List<BlogUser>>(responseBody);
        }
    }
}