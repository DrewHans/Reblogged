using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Fakes
{
    public class MockIFileDataAccess<T> : StubIFileDataAccess<T>
    {
        public void VerifyClearDatabase(string filePath)
        {
            _mockIFileDataAccess
                .Verify(x => x.ClearDatabase(filePath));
        }

        public void VerifyClearDatabaseCalled(int timesCalled)
        {
            _mockIFileDataAccess
                .Verify(x => x.ClearDatabase(It.IsAny<string>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyClearDatabaseNeverCalled()
        {
            _mockIFileDataAccess
                .Verify(x => x.ClearDatabase(It.IsAny<string>()),
                    Times.Never());
        }

        public void VerifyOverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess
                .Verify(x => x.OverwriteDatabase(filePath, listOfEntity));
        }

        public void VerifyOverwriteDatabaseCalled(int timesCalled)
        {
            _mockIFileDataAccess
                .Verify(x => x.OverwriteDatabase(It.IsAny<string>(), It.IsAny<List<T>>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyOverwriteDatabaseNeverCalled()
        {
            _mockIFileDataAccess
                .Verify(x => x.OverwriteDatabase(It.IsAny<string>(), It.IsAny<List<T>>()),
                    Times.Never());
        }

        public void VerifyReadDatabase(string filePath)
        {
            _mockIFileDataAccess
                .Verify(x => x.ReadDatabase(filePath));
        }

        public void VerifyReadDatabaseCalled(int timesCalled)
        {
            _mockIFileDataAccess
                .Verify(x => x.ReadDatabase(It.IsAny<string>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyReadDatabaseNeverCalled()
        {
            _mockIFileDataAccess
                .Verify(x => x.ReadDatabase(It.IsAny<string>()),
                    Times.Never());
        }

        public void VerifyWriteToDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess
                .Verify(x => x.WriteToDatabase(filePath, listOfEntity));
        }

        public void VerifyWriteToDatabase(string filePath, T entity)
        {
            _mockIFileDataAccess
                .Verify(x => x.WriteToDatabase(filePath, entity));
        }

        public void VerifyWriteToDatabaseNeverCalled()
        {
            _mockIFileDataAccess
                .Verify(x => x.WriteToDatabase(It.IsAny<string>(), It.IsAny<List<T>>()),
                    Times.Never());
            _mockIFileDataAccess
                .Verify(x => x.WriteToDatabase(It.IsAny<string>(), It.IsAny<T>()),
                    Times.Never());
        }
    }
}
