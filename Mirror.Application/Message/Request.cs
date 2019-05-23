using System;

namespace Mirror.Application.Message
{
    public abstract class Request : IMessage
    {
        public Request(Guid id, string key)
        {
            Id = id;
            Key = key;
        }

        public Guid Id { get; set; }

        public string Key { get; set; }
    }
}