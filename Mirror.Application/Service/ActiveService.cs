using System.Collections.Generic;
using System.Linq;
using Mirror.Common.Model;
using Mirror.Data.Entities;

namespace Mirror.Application.Service
{
    public class ActiveService : Adaptable<Data.Entities.Service>
    {
        public ActiveService(Data.Entities.Service from) : base(from)
        {
            Key = from.Key;
            Name = from.Name;
            Description = from.Description;
            Vendors = from
                .Vendors
                .Select(vendor => new ActiveVendor(vendor))
                .ToList();
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ActiveVendor> Vendors { get; set; }

        public override Data.Entities.Service ToAdaptable() => new Data.Entities.Service
        {
            Key = Key,
            Name = Name,
            Description = Description,
            Vendors = Vendors.Select(vendor => vendor.ToAdaptable()).ToList()
        };
    }
}