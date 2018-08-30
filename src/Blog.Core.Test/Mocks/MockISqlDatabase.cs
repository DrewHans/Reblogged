using Blog.Core;
using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Mocks
{
    public class MockISqlDatabase : ISqlDatabase
    {
        private readonly Mock<ISqlDatabase> _mockISqlDatabase;

        public MockISqlDatabase()
        {
            _mockISqlDatabase = new Mock<ISqlDatabase>();
        }

        public int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure)
        {
            return _mockISqlDatabase.Object.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure);
        }

        public int ExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            return _mockISqlDatabase.Object.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure, listOfSqlParameters);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure)
        {
            return _mockISqlDatabase.Object.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure);
        }

        public List<T> ExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            return _mockISqlDatabase.Object.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure);
        }

        public MockISqlDatabase StubExecuteNonQueryStoredProcedure(int stub)
        {
            _mockISqlDatabase.Setup(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public MockISqlDatabase StubExecuteReaderStoredProcedure<T>(List<T> stub)
        {
            _mockISqlDatabase.Setup(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public void VerifyExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure)
        {
            _mockISqlDatabase.Verify(x => x.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure));
        }

        public void VerifyExecuteNonQueryStoredProcedure(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            _mockISqlDatabase.Verify(x => x.ExecuteNonQueryStoredProcedure(
                sqlConnectionString, storedProcedure, listOfSqlParameters));
        }

        public void VerifyExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure)
        {
            _mockISqlDatabase.Verify(x => x.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure));
        }

        public void VerifyExecuteReaderStoredProcedure<T>(
            string sqlConnectionString, string storedProcedure,
            List<SqlParameter> listOfSqlParameters)
        {
            _mockISqlDatabase.Verify(x => x.ExecuteReaderStoredProcedure<T>(
                sqlConnectionString, storedProcedure));
        }
    }
}
