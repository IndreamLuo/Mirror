using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mirror.Data;
using Mirror.Data.Entities;

namespace Mirror.Application.Service
{
    public class ServiceManager : IServiceManager
    {
        readonly MirrorDbContext DbContext;

        public ServiceManager(MirrorDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Data.Entities.Service this[string key] => Services.FirstOrDefault(service => service.Key == key);

        public IEnumerable<Data.Entities.Service> Services => DbContext.Services;

        public void AddService(Data.Entities.Service service)
        {
            throw new System.NotImplementedException();
        }

        public void AddVendor(string serviceKey, Vendor vendor)
        {
            throw new System.NotImplementedException();
        }
    }
}