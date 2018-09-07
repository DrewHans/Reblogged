using System;
using System.Net.Http;

namespace Blog.Core.Test.Stubs
{
    public class StubHttpRequestMessage : HttpRequestMessage
    {
        public StubHttpRequestMessage()
            : this(HttpMethod.Get)
        { }

        public StubHttpRequestMessage(HttpMethod httpMethod)
        {
            RequestUri = new Uri("https://en.wikipedia.org/wiki/Nyan_Cat");
            Method = httpMethod;
            Content = new StringContent("Blueberry Poptart");
        }
    }
}