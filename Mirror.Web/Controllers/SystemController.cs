using Microsoft.AspNetCore.Mvc;

namespace Mirror.Web.Controllers
{
    public class SystemController : Controller
    {
        public IActionResult Available()
        {
            return Content("true");
        }
    }
}