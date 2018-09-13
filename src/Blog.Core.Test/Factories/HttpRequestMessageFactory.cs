using System;
using System.Net.Http;

namespace Blog.Core.Test
{
    public class HttpRequestMessageFactory : IFactory<HttpRequestMessage>
    {
        private readonly HttpRequestMessage _httpRequestMessage;

        public HttpRequestMessageFactory()
        {
            _httpRequestMessage = new HttpRequestMessage();
        }

        public HttpRequestMessage Create()
        {
            return _httpRequestMessage;
        }

        public HttpRequestMessageFactory StubHttpRequestMessage()
        {
            StubHttpRequestMessage(HttpMethod.Get);
            return this;
        }

        public HttpRequestMessageFactory StubHttpRequestMessage(HttpMethod httpMethod)
        {
            _httpRequestMessage.RequestUri = new Uri("https://en.wikipedia.org/wiki/Nyan_Cat");
            _httpRequestMessage.Method = httpMethod;
            _httpRequestMessage.Content = new StringContent("Blueberry Poptart");
            return this;
        }
    }
}
