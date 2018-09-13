using Moq;

namespace Blog.Core.Test.Fakes
{
    public class MockIFileReader : StubIFileReader
    {
        public void VerifyRead(string filepath)
        {
            _mockIFileReader
                .Verify(x => x.Read(filepath));
        }

        public void VerifyReadCalled(int timesCalled)
        {
            _mockIFileReader
                .Verify(x => x.Read(It.IsAny<string>()),
                    Times.Exactly(timesCalled));
        }

        public void VerifyReadNeverCalled()
        {
            _mockIFileReader
                .Verify(x => x.Read(It.IsAny<string>()),
                    Times.Never());
        }
    }
}
