using Blog.Core;
using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileDatabase<T> : IFileDatabase<T>
    {
        private readonly Mock<IFileDatabase<T>> _mockIFileDatabase;

        public MockIFileDatabase()
        {
            _mockIFileDatabase = new Mock<IFileDatabase<T>>();
        }

        public void ClearDatabase(string filePath)
        {
            _mockIFileDatabase.Object.ClearDatabase(filePath);
        }

        public void OverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDatabase.Object.OverwriteDatabase(filePath, listOfEntity);
        }

        public List<T> ReadDatabase(string filePath)
        {
            return _mockIFileDatabase.Object.ReadDatabase(filePath);
        }

        public void WriteToDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDatabase.Object.WriteToDatabase(filePath, listOfEntity);
        }

        public void WriteToDatabase(string filePath, T entity)
        {
            _mockIFileDatabase.Object.WriteToDatabase(filePath, entity);
        }

        public MockIFileDatabase<T> StubReadDatabase(List<T> stub)
        {
            _mockIFileDatabase.Setup(x => x.ReadDatabase(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public void VerifyClearDatabase(string filePath)
        {
            _mockIFileDatabase.Verify(x => x.ClearDatabase(filePath));
        }

        public void VerifyOverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDatabase.Verify(x => x.OverwriteDatabase(filePath, listOfEntity));
        }

        public void VerifyReadDatabase(string filePath)
        {
            _mockIFileDatabase.Verify(x => x.ReadDatabase(filePath));
        }

        public void VerifyWriteToDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDatabase.Verify(x => x.WriteToDatabase(filePath, listOfEntity));
        }

        public void VerifyWriteToDatabase(string filePath, T entity)
        {
            _mockIFileDatabase.Verify(x => x.WriteToDatabase(filePath, entity));
        }
    }
}
