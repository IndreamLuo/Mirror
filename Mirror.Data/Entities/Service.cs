using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        public string Description{ get; set; }
        
        public ICollection<Vendor> Vendors { get; set; }
    }
}