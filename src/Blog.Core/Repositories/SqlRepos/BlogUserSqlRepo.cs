using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public class BlogUserSqlRepo : IBlogUserRepo
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlDatabase _sqlDatabase;
        private readonly ISqlParameterBuilder<BlogUser> _sqlParameterBuilder;
        private readonly string _sqlConnectionStringConfigKey;

        public BlogUserSqlRepo(IConfiguration configuration, ISqlDatabase sqlDatabase,
            ISqlParameterBuilder<BlogUser> sqlParameterBuilder)
        {
            _configuration = configuration;
            _sqlDatabase = sqlDatabase;
            _sqlParameterBuilder = sqlParameterBuilder;
            _sqlConnectionStringConfigKey = _configuration["sqldatabase_connectionstring"];
        }

        public void Add(BlogUser entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_bloguser_add"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("Permissions", entity.Permissions));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeRegistered", entity.TimeRegistered));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserId", entity.UserId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserName", entity.UserName));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Add");
        }

        public void Delete(BlogUser entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_bloguser_delete"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserId", entity.UserId));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Delete");
        }

        public void Edit(BlogUser entity)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_bloguser_edit"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("Permissions", entity.Permissions));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("TimeRegistered", entity.TimeRegistered));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserId", entity.UserId));
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserName", entity.UserName));
            var rowsAffected = _sqlDatabase.ExecuteNonQueryStoredProcedure(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (rowsAffected < 1)
                throw new Exception("BlogUserSqlRepo failed to Edit");
        }

        public BlogUser GetById(Guid id)
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_bloguser_getbyid"];
            var listOfSqlParameters = new List<SqlParameter>();
            listOfSqlParameters.Add(_sqlParameterBuilder.BuildSqlParameter("UserId", id));
            var listReturned = _sqlDatabase.ExecuteReaderStoredProcedure<BlogUser>(sqlConnectionString, storedProcedure, listOfSqlParameters);
            if (listReturned.Count != 1)
                return null;
            return listReturned[0];
        }

        public List<BlogUser> List()
        {
            var sqlConnectionString = _configuration[_sqlConnectionStringConfigKey];
            var storedProcedure = _configuration["sqldatabase_storedprocedure_bloguser_list"];
            return _sqlDatabase.ExecuteReaderStoredProcedure<BlogUser>(sqlConnectionString, storedProcedure);
        }
    }
}