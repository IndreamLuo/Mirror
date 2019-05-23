using System;
using System.Net.Http;

namespace Mirror.Application.Message.Requests
{
    public class HttpPostRequest : Request
    {
        public HttpPostRequest(Guid id, string key, HttpContent httpContent) : base(id, key)
        {
            HttpContent = httpContent;
        }

        public HttpContent HttpContent { get; private set; }
    }
}