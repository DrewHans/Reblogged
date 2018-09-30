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

        public BlogPostSqlServerAdapter(IConfiguration configuration, ISqlServerDataAccess sqlServerDataAccess,
            ISqlParameterBuilder sqlParameterBuilder)
        {
            _configuration = configuration;
            _sqlServerDataAccess = sqlServerDataAccess;
            _sqlParameterBuilder = sqlParameterBuilder;
        }

        public void Add(BlogPost entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Add];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public void Delete(BlogPost entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Delete];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public void DeleteAllByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_DeleteAllByAuthorId];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", id));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public void Edit(BlogPost entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_Edit];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", entity.AuthorId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostBody", entity.PostBody));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", entity.PostId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostTitle", entity.PostTitle));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeCreated", entity.TimeCreated));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("TimeLastModified", entity.TimeLastModified));
            var rowsAffected = _sqlServerDataAccess.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public BlogPost GetById(Guid id)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_GetById];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("PostId", id));
            var listReturned = _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (listReturned.Count != 1)
                return null;
            return listReturned[0];
        }

        public List<BlogPost> List()
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_List];
            return _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure);
        }

        public List<BlogPost> ListByAuthorId(Guid id)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogPost_ListByAuthorId];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogPost>("AuthorId", id));
            return _sqlServerDataAccess.ExecuteReaderStoredProcedure<BlogPost>(sqlConnectionString, storedProcedure, listOfSqlParameters);
        }
    }
}