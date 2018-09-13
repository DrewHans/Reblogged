using Moq;

namespace Blog.Core.Test.Fakes
{
    public class MockIFileWriter : StubIFileWriter
    {
        public void VerifyWrite(string filepath, bool appendToFile, string value)
        {
            _mockIFileWriter
                .Verify(x => x.Write(filepath, appendToFile, value));
        }

        public void VerifyWriteCalled(int timesCalled)
        {
            _mockIFileWriter
                .Verify(x => x.Write(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyWriteNeverCalled()
        {
            _mockIFileWriter
                .Verify(x => x.Write(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>()),
                    Times.Never());
        }
    }
}
