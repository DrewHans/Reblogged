using System.Net;
using System.Net.Http;

namespace Blog.Core.Test
{
    public class HttpResponseMessageFactory : IFactory<HttpResponseMessage>
    {
        private readonly HttpResponseMessage _httpResponseMessage;

        public HttpResponseMessageFactory()
        {
            _httpResponseMessage = new HttpResponseMessage();
        }

        public HttpResponseMessage Create()
        {
            return _httpResponseMessage;
        }

        public HttpResponseMessageFactory StubHttpResponseMessage()
        {
            StubHttpResponseMessage(HttpStatusCode.OK);
            return this;
        }

        public HttpResponseMessageFactory StubHttpResponseMessage(HttpStatusCode statusCode)
        {
            _httpResponseMessage.StatusCode = statusCode;
            _httpResponseMessage.Content = new StringContent("S'mores Poptart");
            return this;
        }
    }
}
