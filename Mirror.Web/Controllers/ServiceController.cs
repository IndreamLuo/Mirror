using Microsoft.AspNetCore.Mvc;
using Mirror.Application.Service;

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
    }
}