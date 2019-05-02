using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mirror.Utility;

namespace Mirror.Application.Services
{
    public class Service
    {
        public Service(Data.Entities.Service serviceEntity)
        {
            Vendors = new ReadOnlyDictionary<int, Vendor>(VendorsSource = new Dictionary<int, Vendor>());
        }

        protected IDictionary<int, Vendor> VendorsSource;
        public ReadOnlyDictionary<int, Vendor> Vendors { get; private set; }

        public void AddVendor(Vendor vendor)
        {
            VendorsSource.Add(vendor.Id, vendor);
        }
    }
}