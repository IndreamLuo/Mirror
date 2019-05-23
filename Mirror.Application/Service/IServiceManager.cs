using System.Collections.Generic;
using Mirror.Data.Entities;

namespace Mirror.Application.Service
{
    public interface IServiceManager
    {
        Data.Entities.Service this[string key] { get; }

        IEnumerable<Data.Entities.Service> Services { get; }

        void AddService(Data.Entities.Service service);

        void AddVendor(string serviceKey, Vendor vendor);
    }
}