using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace Blog.Core
{
    public class BlogPostWebApiAdapter : WebApiAdapter, IBlogPostDataAccessAdapter
    {

        public BlogPostWebApiAdapter(IConfiguration configuration, IWebApiDataAccess webApiDataAccess)
            : base(configuration, webApiDataAccess) { }

        public void Add(BlogPost entity)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_Add;
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

        public void Delete(BlogPost entity)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_Delete;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogPost_Delete_UriQuery_PostId;
            query[queryName] = entity.PostId.ToString();
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

        public void DeleteAllByAuthorId(Guid id)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId_UriQuery_AuthorId;
            query[queryName] = id.ToString();
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

        public void Edit(BlogPost entity)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_Edit;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogPost_Edit_UriQuery_PostId;
            query[queryName] = entity.PostId.ToString();
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

        public BlogPost GetById(Guid id)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_GetById;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogPost_GetById_UriQuery_PostId;
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
            return JsonConvert.DeserializeObject<BlogPost>(responseBody);
        }

        public List<BlogPost> List()
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_List;
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
            return JsonConvert.DeserializeObject<List<BlogPost>>(responseBody);
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            var configKey_webapi_path = KeyChain.WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId;
            var query = HttpUtility.ParseQueryString(string.Empty);
            var queryName = KeyChain.WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId_UriQuery_AuthorId;
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
            return JsonConvert.DeserializeObject<List<BlogPost>>(responseBody);
        }
    }
}