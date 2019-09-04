using Microsoft.AspNetCore.Mvc;
using Mirror.Application.Service;
using Mirror.Web.Models.Service;
using ServiceEntity = Mirror.Data.Entities.Service;

namespace Mirror.Web.Controllers
{
    public class ServiceController : Controller
    {
        readonly IServiceManager ServiceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }
        
        public IActionResult All()
        {
            return Json(ServiceManager.Services);
        }

        [HttpPost]
        public IActionResult Add(ServiceModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceManager.AddService(new ServiceEntity
                {
                    Key = model.Key,
                    Name = model.Name,
                    Description = model.Description
                });

                var entity = ServiceManager[model.Key];
                return Content(entity.Id.ToString());
            }

            return BadRequest(ModelState);
        }
    }
}