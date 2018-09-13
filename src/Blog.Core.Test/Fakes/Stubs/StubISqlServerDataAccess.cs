using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Blog.Core.Test.Fakes
{
    public class StubISqlServerDataAccess : FakeISqlServerDataAccess
    {
        public StubISqlServerDataAccess StubExecuteNonQueryStoredProcedure(int stub)
        {
            _mockISqlServerDataAccess
                .Setup(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public StubISqlServerDataAccess StubGetById(List<int> listOfStubs)
        {
            var stubSequence = _mockISqlServerDataAccess
                .SetupSequence(x => x.ExecuteNonQueryStoredProcedure(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public StubISqlServerDataAccess StubExecuteReaderStoredProcedure<T>(List<T> stub)
        {
            _mockISqlServerDataAccess
                .Setup(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()))
                .Returns(stub);
            return this;
        }

        public StubISqlServerDataAccess StubExecuteReaderStoredProcedure<T>(List<List<T>> listOfStubs)
        {
            var stubSequence = _mockISqlServerDataAccess
                .SetupSequence(x => x.ExecuteReaderStoredProcedure<T>(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<SqlParameter>>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
