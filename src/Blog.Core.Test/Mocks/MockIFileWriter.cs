using Moq;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileWriter : IFileWriter
    {
        private readonly Mock<IFileWriter> _mockIFileWriter;

        public MockIFileWriter()
        {
            _mockIFileWriter = new Mock<IFileWriter>();
        }

        public void Write(string filepath, bool appendToFile, string value)
        {
            _mockIFileWriter.Object.Write(filepath, appendToFile, value);
        }

        public void VerifyWrite(string filepath, bool appendToFile, string value)
        {
            _mockIFileWriter.Verify(x => x.Write(filepath, appendToFile, value));
        }

        public void VerifyWriteNotCalled()
        {
            _mockIFileWriter.Verify(x => x.Write(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Never());
        }
    }
}