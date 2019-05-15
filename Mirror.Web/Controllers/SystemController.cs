using Microsoft.AspNetCore.Mvc;

namespace Mirror.Web.Controllers
{
    public class SystemController : Controller
    {
        [HttpPost]
        public IActionResult Available()
        {
            return Content("true");
        }
    }
}