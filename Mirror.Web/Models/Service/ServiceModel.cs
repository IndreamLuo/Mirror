using System.ComponentModel.DataAnnotations;
using ServiceEntity = Mirror.Data.Entities.Service;

namespace Mirror.Web.Models.Service
{
    public class ServiceModel
    {
        public ServiceModel() { }

        public ServiceModel(ServiceEntity entity)
        {
            Id = entity.Id;
            Key = entity.Key;
            Name = entity.Name;
            Description = entity.Description;
        }

        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}