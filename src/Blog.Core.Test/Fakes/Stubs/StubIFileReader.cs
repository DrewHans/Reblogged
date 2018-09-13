using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Fakes
{
    public class StubIFileReader : FakeIFileReader
    {
        public StubIFileReader StubRead(string stub)
        {
            _mockIFileReader
                .Setup(x => x.Read(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public StubIFileReader StubRead(List<string> listOfStubs)
        {
            var stubSequence = _mockIFileReader
                .SetupSequence(x => x.Read(It.IsAny<string>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
