using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Mocks
{
    public class MockISqlServerDataAccess : ISqlServerDataAccess
    {
        private readonly Mock<ISqlServerDataAccess> _mockISqlServerDataAccess;

        public MockISqlServerDataAccess()
        {
            _mockISqlServerDataAccess = new Mock<ISqlServerDataAccess>();
        }

        public int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure)
        {
            return _mockISqlServerDataAccess.Object.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure);
        }

        public int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            return _mockISqlServerDataAccess.Object.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure)
        {
            return _mockISqlServerDataAccess.Object.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            return _mockISqlServerDataAccess.Object.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure);
        }

        public MockISqlServerDataAccess StubExecuteNonQueryStoredProcedure(int stub)
        {
            _mockISqlServerDataAccess.Setup(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public MockISqlServerDataAccess StubExecuteReaderStoredProcedure<T>(List<T> stub)
        {
            _mockISqlServerDataAccess.Setup(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public void VerifyExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure)
        {
            _mockISqlServerDataAccess.Verify(x => x.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure));
        }

        public void VerifyExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            _mockISqlServerDataAccess.Verify(x => x.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure, listOfSqlParameters));
        }

        public void VerifyExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure)
        {
            _mockISqlServerDataAccess.Verify(x => x.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure));
        }

        public void VerifyExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            _mockISqlServerDataAccess.Verify(x => x.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure));
        }
    }
}
