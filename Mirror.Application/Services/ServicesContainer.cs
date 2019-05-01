using System;
using Mirror.Application.Cache;

namespace Mirror.Application.Services
{
    public class ServicesContainer
    {
        readonly ICache Cache;

        public ServicesContainer(ICache cache)
        {
            Cache = cache;
        }

        public Service this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}