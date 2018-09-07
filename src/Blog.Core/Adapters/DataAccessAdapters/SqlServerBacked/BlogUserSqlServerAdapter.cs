using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class BlogUserSqlServerAdapter : IBlogUserDataAccessAdapter
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlServerDataAccess _sqlserver;
        private readonly ISqlParameterBuilder _sqlParameterBuilder;

        public BlogUserSqlServerAdapter(IConfiguration configuration, ISqlServerDataAccess sqlserver,
            ISqlParameterBuilder sqlParameterBuilder)
        {
            _configuration = configuration;
            _sqlserver = sqlserver;
            _sqlParameterBuilder = sqlParameterBuilder;
        }

        public void Add(BlogUser entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Add];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("Permissions", entity.Permissions));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("TimeRegistered", entity.TimeRegistered));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserId", entity.UserId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserName", entity.UserName));
            var rowsAffected = _sqlserver.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Add");
        }

        public void Delete(BlogUser entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Delete];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserId", entity.UserId));
            var rowsAffected = _sqlserver.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Delete");
        }

        public void Edit(BlogUser entity)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_Edit];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("Permissions", entity.Permissions));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("TimeRegistered", entity.TimeRegistered));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserId", entity.UserId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserName", entity.UserName));
            var rowsAffected = _sqlserver.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Edit");
        }

        public BlogUser GetById(Guid id)
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_GetById];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter<BlogUser>("UserId", id));
            var listReturned = _sqlserver.ExecuteReaderStoredProcedure<BlogUser>(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (listReturned.Count != 1)
                return null;
            return listReturned[0];
        }

        public List<BlogUser> List()
        {
            var sqlConnectionString = _configuration[KeyChain.SqlServerDataAccess_ConnectionString];
            var storedProcedure = _configuration[KeyChain.SqlServerDataAccess_StoredProcedure_BlogUser_List];
            return _sqlserver.ExecuteReaderStoredProcedure<BlogUser>(sqlConnectionString, storedProcedure);
        }
    }
}