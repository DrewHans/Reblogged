using Blog.Core;
using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Mocks
{
    public class MockIFileDatabaseReader : IFileDatabaseReader
    {
        private readonly Mock<IFileDatabaseReader> _mockIFileDatabaseReader;

        public MockIFileDatabaseReader()
        {
            _mockIFileDatabaseReader = new Mock<IFileDatabaseReader>();
        }

        public string Read(string filepath)
        {
            return _mockIFileDatabaseReader.Object.Read(filepath);
        }

        public MockIFileDatabaseReader StubRead(List<string> listOfStubs)
        {
            var stubSequence = _mockIFileDatabaseReader.SetupSequence(x =>
                x.Read(It.IsAny<string>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }

        public MockIFileDatabaseReader StubRead(string stub)
        {
            _mockIFileDatabaseReader.Setup(x => x.Read(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public void VerifyRead(string filepath)
        {
            _mockIFileDatabaseReader.Verify(x => x.Read(filepath));
        }
    }
}