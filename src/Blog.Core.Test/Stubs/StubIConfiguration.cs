using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace Blog.Core.Test.Stubs
{
    public class StubIConfiguration : IConfiguration
    {
        private readonly IDictionary<string, string> _dictionary;

        public string this[string key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        public StubIConfiguration()
        {
            _dictionary = new Dictionary<string, string>();
            _dictionary[KeyChain.FileDataAccess_BlogPost_DatabasePath] = "fake/path/to/blogpost/database.json";
            _dictionary[KeyChain.FileDataAccess_BlogUser_DatabasePath] = "fake/path/to/bloguser/database.json";
            _dictionary[KeyChain.SqlServerDataAccess_ConnectionString] = "Server=SomeServerName;Database=SomeDatabase;MoreSuperSecretFields=MoreSuperSecretValues;";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Add] = "spBlogPostInsert";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Delete] = "spBlogPostDelete";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_DeleteAllByAuthorId] = "spBlogPostDeleteMany";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Edit] = "spBlogPostUpdate";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_GetById] = "spBlogPostSelectById";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_List] = "spBlogPostSelectAll";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_ListByAuthorId] = "spBlogPostSelectAllByAuthorId";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Add] = "spBlogUserInsert";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Delete] = "spBlogUserDelete";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Edit] = "spBlogUserUpdate";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_GetById] = "spBlogUserSelectById";
            _dictionary[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_List] = "spBlogUserSelectAll";
            _dictionary[KeyChain.WebApiDataAccess_AuthScheme] = "Basic";
            _dictionary[KeyChain.WebApiDataAccess_AuthToken] = "UG9wdGFydA==";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Add] = "/blogpost/add";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Delete] = "/blogpost/delete";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId] = "/blogpost/delete";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Edit] = "/blogpost/edit";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_GetById] = "/blogpost/getbyid";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_List] = "/blogpost/list";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId] = "/blogpost/list";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Add] = "/bloguser/add";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Delete] = "/bloguser/delete";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Edit] = "/bloguser/edit";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogUser_GetById] = "/bloguser/getbyid";
            _dictionary[KeyChain.WebApiDataAccess_Endpoint_BlogUser_List] = "/bloguser/list";
            _dictionary[KeyChain.WebApiDataAccess_UriScheme] = "http";
            _dictionary[KeyChain.WebApiDataAccess_UriHost] = "somefakehost.com";
            _dictionary[KeyChain.WebApiDataAccess_UriPort] = "3000";
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new System.NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new System.NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
