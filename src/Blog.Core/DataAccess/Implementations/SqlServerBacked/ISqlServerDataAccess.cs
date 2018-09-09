using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core
{
    public interface ISqlServerDataAccess
    {
        int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters = null);
        List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters = null);
    }
}