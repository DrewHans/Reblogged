using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class BlogPostSqlServerAdapter : IBlogPostDataAccessAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlServerDataAccess _sqlServerDataAccess;
        private readonly ISqlParameterBuilder _sqlParameterBuilder;
        private readonly string _sqlConnectionStringConfigKey;

        public BlogPostSqlServerAdapter(IConfiguration configuration, ISqlServerDataAccess sqlServerDataAccess,
            ISqlParameterBuilder sqlParameterBuilder)
        {
            _configuration = configuration;
            _sqlServerDataAccess = sqlServerDataAccess;
            _sqlParameterBuilder = sqlParameterBuilder;
            _sqlConnectionStringConfigKey = "sqldatabase_connectionstring";
        }

        public void Add(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_add"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Add");
        }

        public void Delete(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_delete"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Delete");
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_deleteallbyauthorid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", id));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public void Edit(BlogPost entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_edit"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogPostSqlRepo failed to Edit");
        }

        public BlogPost GetById(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_getbyid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", id));
            var listReturned = _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (listReturned.Count != 1)
                return null;
            return listReturned[0];
        }

        public List<BlogPost> List()
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_list"];
            return _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure);
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_blogpost_listbyauthorid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", id));
            return _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }
    }
}