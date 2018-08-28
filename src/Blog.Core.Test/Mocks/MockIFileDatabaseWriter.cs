using Blog.Core;
using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileDatabaseWriter : IFileDatabaseWriter
    {
        private readonly Mock<IFileDatabaseWriter> _mockIFileDatabaseWriter;

        public MockIFileDatabaseWriter()
        {
            _mockIFileDatabaseWriter = new Mock<IFileDatabaseWriter>();
        }

        public void Write(string filepath, bool appendToFile, string value)
        {
            _mockIFileDatabaseWriter.Object.Write(filepath, appendToFile, value);
        }

        public void VerifyWrite(string filepath, bool appendToFile, string value)
        {
            _mockIFileDatabaseWriter.Verify(x => x.Write(filepath, appendToFile, value));
        }

        public void VerifyWriteNotCalled()
        {
            _mockIFileDatabaseWriter.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Never());
        }
    }
}