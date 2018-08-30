using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class BlogPostSqlRepo : IBlogPostRepo
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlDatabase _sqlDatabase;
        private readonly ISqlParameterBuilder<BlogPost> _sqlParameterBuilder;
        private readonly string _sqlConnectionStringConfigKey;

        public BlogPostSqlRepo(IConfiguration configuration, ISqlDatabase sqlDatabase,
            ISqlParameterBuilder<BlogPost> sqlParameterBuilder)
        {
            _configuration = configuration;
            _sqlDatabase = sqlDatabase;
            _sqlParameterBuilder = sqlParameterBuilder;
            _sqlConnectionStringConfigKey = _configuration["sqldatabase_connectionstring"];
        }

        public void Add(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_add"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Add");
        }

        public void Delete(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_delete"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostId", entity.PostId));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Delete");
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_deleteallbyauthorid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("AuthorId", id));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public void Edit(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_edit"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Edit");
        }

        public BlogPost GetById(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_getbyid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("AuthorId", id));
            var listReturned = _sqlDatabase.ExecuteBlogPostReaderStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (listReturned.Count != 1)
                return null;
            return listReturned[0];
        }

        public List<BlogPost> List()
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_list"];
            return _sqlDatabase.ExecuteBlogPostReaderStoredProcedure(sqlConnectionString, storedProcedure);
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_listbyauthorid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("AuthorId", id));
            return _sqlDatabase.ExecuteBlogPostReaderStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }
    }
}