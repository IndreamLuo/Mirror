using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public abstract class Entity
    {

    }

    public abstract class Entity<TId> : Entity
    {
        [Key]
        public TId Id { get; set; }
    }
}