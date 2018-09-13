using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Fakes
{
    public class MockISqlServerDataAccess : StubISqlServerDataAccess
    {
        public void VerifyExecuteNonQueryStoredProcedure(string sqlConnectionString,
            string storedProcedure, List<SqlParameter> listOfSqlParameters = null)
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteNonQueryStoredProcedure(
                    sqlConnectionString, storedProcedure, listOfSqlParameters));
        }

        public void VerifyExecuteNonQueryStoredProcedureCalled(int timesCalled)
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyExecuteNonQueryStoredProcedureNeverCalled()
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()),
                    Times.Never());
        }

        public void VerifyExecuteReaderStoredProcedure<T>(string sqlConnectionString,
            string storedProcedure, List<SqlParameter> listOfSqlParameters = null)
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteReaderStoredProcedure<T>(
                    sqlConnectionString, storedProcedure, listOfSqlParameters));
        }

        public void VerifyExecuteReaderStoredProcedureCalled<T>(int timesCalled)
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyExecuteReaderStoredProcedureNeverCalled<T>()
        {
            _mockISqlServerDataAccess
                .Verify(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()),
                    Times.Never());
        }
    }
}
