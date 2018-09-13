using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeISqlServerDataAccess : ISqlServerDataAccess
    {
        protected readonly Mock<ISqlServerDataAccess> _mockISqlServerDataAccess;

        public FakeISqlServerDataAccess()
        {
            _mockISqlServerDataAccess = new Mock<ISqlServerDataAccess>();
        }

        public int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters = null)
        {
            return _mockISqlServerDataAccess.Object.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters = null)
        {
            return _mockISqlServerDataAccess.Object.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure);
        }
    }
}
