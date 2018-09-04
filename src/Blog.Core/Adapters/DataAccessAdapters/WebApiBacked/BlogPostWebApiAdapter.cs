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
            var configKey_webapi_path = "webapi_blogpost_add";
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
            var configKey_webapi_path = "webapi_blogpost_delete";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["postid"] = entity.PostId.ToString();
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
            var configKey_webapi_path = "webapi_blogpost_deleteallbyauthorid";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["authorid"] = id.ToString();
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
            var configKey_webapi_path = "webapi_blogpost_edit";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["postid"] = entity.PostId.ToString();
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
            var configKey_webapi_path = "webapi_blogpost_getbyid";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["postid"] = id.ToString();
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
            var configKey_webapi_path = "webapi_blogpost_list";
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
            var configKey_webapi_path = "webapi_blogpost_listbyauthorid";
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["authorid"] = id.ToString();
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