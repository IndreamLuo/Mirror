using System;

namespace Mirror.Application.Message
{
    public interface IMessage
    {
        Guid Id { get; set; }
    }
}