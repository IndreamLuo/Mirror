using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Vendor : Common.Model.Vendor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public override string Url { get; set; }

        [Required]
        public Service Service { get; set; }
    }
}