using Moq;
using System.Collections.Generic;
using System.Net.Http;

namespace Blog.Core.Test.Fakes
{
    public class StubIWebApiDataAccess : FakeIWebApiDataAccess
    {
        public StubIWebApiDataAccess StubSendRequest(HttpResponseMessage stub)
        {
            _mockIWebApiDataAccess
                .Setup(x => x.SendRequest(It.IsAny<HttpRequestMessage>()))
                .Returns(stub);
            return this;
        }

        public StubIWebApiDataAccess StubSendRequest(List<HttpResponseMessage> listOfStubs)
        {
            var stubSequence = _mockIWebApiDataAccess
                .SetupSequence(x => x.SendRequest(It.IsAny<HttpRequestMessage>()));
            listOfStubs.ForEach(stub => stubSequence.Returns(stub));
            return this;
        }
    }
}
