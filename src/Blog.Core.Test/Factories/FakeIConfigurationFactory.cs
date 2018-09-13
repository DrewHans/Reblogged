using Blog.Core.Test.Fakes;

namespace Blog.Core.Test
{
    public class FakeIConfigurationFactory : IFactory<FakeIConfiguration>
    {
        private readonly FakeIConfiguration _fakeConfig;

        public FakeIConfigurationFactory()
        {
            _fakeConfig = new FakeIConfiguration();
        }

        public FakeIConfiguration Create()
        {
            return _fakeConfig;
        }

        public FakeIConfigurationFactory StubFakeDataForFileDataAccess()
        {
            _fakeConfig[KeyChain.FileDataAccess_BlogPost_DatabasePath] = "fake/path/to/blogpost/database.json";
            _fakeConfig[KeyChain.FileDataAccess_BlogUser_DatabasePath] = "fake/path/to/bloguser/database.json";
            return this;
        }

        public FakeIConfigurationFactory StubFakeDataForSqlServerDataAccess()
        {
            _fakeConfig[KeyChain.SqlServerDataAccess_ConnectionString] = "Server=SomeServerName;Database=SomeDatabase;MoreSuperSecretFields=MoreSuperSecretValues;";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Add] = "spBlogPostInsert";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Delete] = "spBlogPostDelete";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_DeleteAllByAuthorId] = "spBlogPostDeleteMany";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Edit] = "spBlogPostUpdate";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_GetById] = "spBlogPostSelectById";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_List] = "spBlogPostSelectAll";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_ListByAuthorId] = "spBlogPostSelectAllByAuthorId";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Add] = "spBlogUserInsert";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Delete] = "spBlogUserDelete";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Edit] = "spBlogUserUpdate";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_GetById] = "spBlogUserSelectById";
            _fakeConfig[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_List] = "spBlogUserSelectAll";
            return this;
        }

        public FakeIConfigurationFactory StubFakeDataForWebApiDataAccess()
        {
            _fakeConfig[KeyChain.WebApiDataAccess_AuthScheme] = "Basic";
            _fakeConfig[KeyChain.WebApiDataAccess_AuthToken] = "UG9wdGFydA==";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Add] = "/blogpost/add";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Delete] = "/blogpost/delete";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId] = "/blogpost/delete";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_Edit] = "/blogpost/edit";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_GetById] = "/blogpost/getbyid";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_List] = "/blogpost/list";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId] = "/blogpost/list";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Add] = "/bloguser/add";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Delete] = "/bloguser/delete";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogUser_Edit] = "/bloguser/edit";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogUser_GetById] = "/bloguser/getbyid";
            _fakeConfig[KeyChain.WebApiDataAccess_Endpoint_BlogUser_List] = "/bloguser/list";
            _fakeConfig[KeyChain.WebApiDataAccess_UriScheme] = "http";
            _fakeConfig[KeyChain.WebApiDataAccess_UriHost] = "somefakehost.com";
            _fakeConfig[KeyChain.WebApiDataAccess_UriPort] = "3000";
            return this;
        }
    }
}
