using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Url { get; set; }

        [Required]
        public Service Service { get; set; }
    }
}