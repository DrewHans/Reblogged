using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Fakes
{
    public abstract class FakeIFileDataAccess<T> : IFileDataAccess<T>
    {
        private readonly Mock<IFileDataAccess<T>> _mockIFileDataAccess;

        public FakeIFileDataAccess()
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
    }
}
