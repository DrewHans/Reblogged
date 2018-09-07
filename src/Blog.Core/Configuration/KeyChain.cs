namespace Blog.Core
{
    public static class KeyChain
    {
        // This KeyChain class is exists to centralize
        //  "magic strings" used throughout Blog.Core.
        public const string FileDataAccess_BlogPost_DatabasePath
            = "fileDataAccess_blogpost_path";
        public const string FileDataAccess_BlogUser_DatabasePath
            = "fileDataAccess_bloguser_path";

        public const string SqlServerDataAccess_BlogPost_ColumnName_AuthorId
            = "authorid";
        public const string SqlServerDataAccess_BlogPost_ColumnName_PostBody
            = "postbody";
        public const string SqlServerDataAccess_BlogPost_ColumnName_PostId
            = "postid";
        public const string SqlServerDataAccess_BlogPost_ColumnName_PostTitle
            = "posttitle";
        public const string SqlServerDataAccess_BlogPost_ColumnName_TimeCreated
            = "timecreated";
        public const string SqlServerDataAccess_BlogPost_ColumnName_TimeLastModified
            = "timelastmodified";
        public const string SqlServerDataAccess_BlogPost_TableName
            = "blogpost";
        public const string SqlServerDataAccess_BlogUser_ColumnName_Permissions
            = "permissions";
        public const string SqlServerDataAccess_BlogUser_ColumnName_TimeRegistered
            = "timeregistered";
        public const string SqlServerDataAccess_BlogUser_ColumnName_UserId
            = "userid";
        public const string SqlServerDataAccess_BlogUser_ColumnName_UserName
            = "username";
        public const string SqlServerDataAccess_BlogUser_TableName
            = "bloguser";
        public const string SqlServerDataAccess_ConnectionString
            = "sqlserver_connectionstring";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_Add
            = "sqlserver_sp_blogpost_add";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_Delete
            = "sqlserver_sp_blogpost_delete";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_DeleteAllByAuthorId
            = "sqlserver_sp_blogpost_deleteallbyauthorid";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_Edit
            = "sqlserver_sp_blogpost_edit";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_GetById
            = "sqlserver_sp_blogpost_getbyid";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_List
            = "sqlserver_sp_blogpost_list";
        public const string SqlServerDataAccess_StoredProcedure_BlogPost_ListByAuthorId
            = "sqlserver_sp_blogpost_listbyauthorid";
        public const string SqlServerDataAccess_StoredProcedure_BlogUser_Add
            = "sqlserver_sp_bloguser_add";
        public const string SqlServerDataAccess_StoredProcedure_BlogUser_Delete
            = "sqlserver_sp_bloguser_delete";
        public const string SqlServerDataAccess_StoredProcedure_BlogUser_Edit
            = "sqlserver_sp_bloguser_edit";
        public const string SqlServerDataAccess_StoredProcedure_BlogUser_GetById
            = "sqlserver_sp_bloguser_getbyid";
        public const string SqlServerDataAccess_StoredProcedure_BlogUser_List
            = "sqlserver_sp_bloguser_list";

        public const string WebApiDataAccess_AuthScheme
            = "webapi_authscheme";
        public const string WebApiDataAccess_AuthToken
            = "webapi_authtoken";
        public const string WebApiDataAccess_Endpoint_BlogPost_Add
            = "webapi_endpoint_blogpost_add";
        public const string WebApiDataAccess_Endpoint_BlogPost_Delete
            = "webapi_endpoint_blogpost_delete";
        public const string WebApiDataAccess_Endpoint_BlogPost_Delete_UriQuery_PostId
            = "postid";
        public const string WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId
            = "webapi_endpoint_blogpost_deleteallbyauthorid";
        public const string WebApiDataAccess_Endpoint_BlogPost_DeleteAllByAuthorId_UriQuery_AuthorId
            = "authorid";
        public const string WebApiDataAccess_Endpoint_BlogPost_Edit
            = "webapi_endpoint_blogpost_edit";
        public const string WebApiDataAccess_Endpoint_BlogPost_Edit_UriQuery_PostId
            = "postid";
        public const string WebApiDataAccess_Endpoint_BlogPost_GetById
            = "webapi_endpoint_blogpost_getbyid";
        public const string WebApiDataAccess_Endpoint_BlogPost_GetById_UriQuery_PostId
            = "postid";
        public const string WebApiDataAccess_Endpoint_BlogPost_List
            = "webapi_endpoint_blogpost_list";
        public const string WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId
            = "webapi_endpoint_blogpost_listbyauthorid";
        public const string WebApiDataAccess_Endpoint_BlogPost_ListByAuthorId_UriQuery_AuthorId
            = "authorid";
        public const string WebApiDataAccess_Endpoint_BlogUser_Add
            = "webapi_endpoint_bloguser_add";
        public const string WebApiDataAccess_Endpoint_BlogUser_Delete
            = "webapi_endpoint_bloguser_delete";
        public const string WebApiDataAccess_Endpoint_BlogUser_Delete_UriQuery_UserId
            = "userid";
        public const string WebApiDataAccess_Endpoint_BlogUser_Edit
            = "webapi_endpoint_bloguser_edit";
        public const string WebApiDataAccess_Endpoint_BlogUser_Edit_UriQuery_UserId
            = "userid";
        public const string WebApiDataAccess_Endpoint_BlogUser_GetById
            = "webapi_endpoint_bloguser_getbyid";
        public const string WebApiDataAccess_Endpoint_BlogUser_GetById_UriQuery_UserId
            = "userid";
        public const string WebApiDataAccess_Endpoint_BlogUser_List
            = "webapi_endpoint_bloguser_list";
        public const string WebApiDataAccess_UriScheme
            = "webapi_urischeme";
        public const string WebApiDataAccess_UriHost
            = "webapi_urihost";
        public const string WebApiDataAccess_UriPort
            = "webapi_uriport";
    }
}