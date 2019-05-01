using System.Collections.Generic;
using Mirror.Utility;

namespace Mirror.Application.Services
{
    public class Service
    {
        public Service(Data.Entities.Service serviceEntity)
        {
            Vendors = new ReadonlyDictionary<int, Vendor>(out VendorsSource);
        }

        protected IDictionary<int, Vendor> VendorsSource;
        public ReadonlyDictionary<int, Vendor> Vendors { get; private set; }

        public void AddVendor(Vendor vendor)
        {
            VendorsSource.Add(vendor.Id, vendor);
        }
    }
}