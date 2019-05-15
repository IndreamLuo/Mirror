using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}