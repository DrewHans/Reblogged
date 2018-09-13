using Moq;
using System.Collections.Generic;

namespace Blog.Core.Test.Fakes
{
    public class StubIFileDataAccess<T> : FakeIFileDataAccess<T>
    {
        public StubIFileDataAccess<T> StubReadDatabase(List<T> stub)
        {
            _mockIFileDataAccess
                .Setup(x => x.ReadDatabase(It.IsAny<string>()))
                .Returns(stub);
            return this;
        }

        public StubIFileDataAccess<T> StubReadDatabase(List<List<T>> listOfStubs)
        {
            var stubSequence = _mockIFileDataAccess
                .SetupSequence(x => x.ReadDatabase(It.IsAny<string>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
