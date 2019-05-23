using System.Collections.Generic;

namespace Mirror.Application.Message
{
    public interface IMessageApplication
    {
        IEnumerable<Response> Require(Request request);
    }
}