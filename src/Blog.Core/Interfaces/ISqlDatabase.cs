using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public interface ISqlDatabase
    {
        int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure);
        int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure, List<SqlParameter> listOfSqlParameters);
        List<BlogPost> ExecuteBlogPostReaderStoredProcedure(
            string sqlConnectionString, string storedProcedure);
        List<BlogPost> ExecuteBlogPostReaderStoredProcedure(
            string sqlConnectionString, string storedProcedure, List<SqlParameter> listOfSqlParameters);
        List<BlogUser> ExecuteBlogUserReaderStoredProcedure(
            string sqlConnectionString, string storedProcedure);
        List<BlogUser> ExecuteBlogUserReaderStoredProcedure(
            string sqlConnectionString, string storedProcedure, List<SqlParameter> listOfSqlParameters);
    }
}