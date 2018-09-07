using System.Net;
using System.Net.Http;

namespace Blog.Core.Test.Stubs
{
    public class StubHttpResponseMessage : HttpResponseMessage
    {
        public StubHttpResponseMessage()
            : this(HttpStatusCode.OK)
        { }

        public StubHttpResponseMessage(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Content = new StringContent("S'mores Poptart");
        }
    }
}