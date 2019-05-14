using System.Collections.Generic;

namespace Mirror.Common.Model
{
    public class Service
    {
        public virtual string Key { get; set; }

        public virtual string Description{ get; set; }
        
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}