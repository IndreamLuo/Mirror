using System.Net.Http;

namespace Mirror.Application.Message.Responses
{
    public class HttpResponse : Response
    {
        public HttpResponse(Request request, HttpResponseMessage httpResponseMessage) : base(request)
        {
            HttpResponseMessage = httpResponseMessage;
        }

        public HttpResponseMessage HttpResponseMessage { get; private set; }
    }
}