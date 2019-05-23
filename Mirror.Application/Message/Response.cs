using System;

namespace Mirror.Application.Message
{
    public abstract class Response : IMessage
    {
        internal Response(Request request)
        {
            Id = request.Id;
        }

        public Guid Id { get; set; }
    }
}