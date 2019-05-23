using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public abstract class Entity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}