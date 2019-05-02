using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mirror.Application.Cache;

namespace Mirror.Application.Services
{
    public class ServicesContainer
    {
        readonly ICache Cache;

        public ServicesContainer(ICache cache)
        {
            Cache = cache;
            Services = new ReadOnlyDictionary<string, Service>(ServicesDataSource = new Dictionary<string, Service>());
        }

        public Service this[string key]
        {
            get => Services[key];
        }

        protected readonly IDictionary<string, Service> ServicesDataSource;
        public readonly ReadOnlyDictionary<string, Service> Services;
    }
}