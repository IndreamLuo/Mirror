using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mirror.Data.Entities
{
    public class Service : Common.Model.Service, IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public override string Key { get; set; }
    }
}