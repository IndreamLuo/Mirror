using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Vendor : Entity<int>
    {
        
        [Required]
        public string Url { get; set; }

        [Required]
        public Service Service { get; set; }
    }
}