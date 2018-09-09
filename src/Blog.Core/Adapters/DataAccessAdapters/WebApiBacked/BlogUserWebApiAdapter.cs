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
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogUser_Add;
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
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogUser_Delete;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogUser_Delete_UriQuery_UserId;
            query[queryName] = entity.UserId.ToString();
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
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogUser_Edit;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogUser_Edit_UriQuery_UserId;
            query[queryName] = entity.UserId.ToString();
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
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogUser_GetById;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogUser_GetById_UriQuery_UserId;
            query[queryName] = id.ToString();
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
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogUser_List;
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