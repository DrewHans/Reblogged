using Blog.Core;
using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileReader : IFileReader
    {
        private readonly Mock<IFileReader> _mockIFileReader;

        public MockIFileReader()
        {
            _mockIFileReader = new Mock<IFileReader>();
        }

        public string Read(string filepath)
        {
            return _mockIFileReader.Object.Read(filepath);
        }

        public MockIFileReader StubRead(List<string> listOfStubs)
        {
            var stubSequence = _mockIFileReader.SetupSequence(x =>
                x.Read(It.IsAny<string>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public MockIFileReader StubRead(string stub)
        {
            _mockIFileReader.Setup(x => x.Read(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public void VerifyRead(string filepath)
        {
            _mockIFileReader.Verify(x => x.Read(filepath));
        }
    }
}