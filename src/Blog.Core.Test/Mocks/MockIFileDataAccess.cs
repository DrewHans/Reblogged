using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileDataAccess<T> : IFileDataAccess<T>
    {
        private readonly Mock<IFileDataAccess<T>> _mockIFileDataAccess;

        public MockIFileDataAccess()
        {
            _mockIFileDataAccess = new Mock<IFileDataAccess<T>>();
        }

        public void ClearDatabase(string filePath)
        {
            _mockIFileDataAccess.Object.ClearDatabase(filePath);
        }

        public void OverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess.Object.OverwriteDatabase(filePath, listOfEntity);
        }

        public List<T> ReadDatabase(string filePath)
        {
            return _mockIFileDataAccess.Object.ReadDatabase(filePath);
        }

        public void WriteToDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess.Object.WriteToDatabase(filePath, listOfEntity);
        }

        public void WriteToDatabase(string filePath, T entity)
        {
            _mockIFileDataAccess.Object.WriteToDatabase(filePath, entity);
        }

        public MockIFileDataAccess<T> StubReadDatabase(List<T> stub)
        {
            _mockIFileDataAccess
                .Setup(x => x.ReadDatabase(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public void VerifyClearDatabase(string filePath)
        {
            _mockIFileDataAccess.Verify(x => x.ClearDatabase(filePath));
        }

        public void VerifyOverwriteDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess.Verify(x => x.OverwriteDatabase(filePath, listOfEntity));
        }

        public void VerifyReadDatabase(string filePath)
        {
            _mockIFileDataAccess.Verify(x => x.ReadDatabase(filePath));
        }

        public void VerifyWriteToDatabase(string filePath, List<T> listOfEntity)
        {
            _mockIFileDataAccess.Verify(x => x.WriteToDatabase(filePath, listOfEntity));
        }

        public void VerifyWriteToDatabase(string filePath, T entity)
        {
            _mockIFileDataAccess.Verify(x => x.WriteToDatabase(filePath, entity));
        }
    }
}
