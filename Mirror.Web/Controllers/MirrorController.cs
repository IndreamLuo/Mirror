using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Mirror.Application.Message;
using Mirror.Application.Message.Requests;
using Mirror.Web.Models.Mirror;

namespace Mirror.Web.Controllers
{
    [Route("Mirror")]
    public class MirrorController : Controller
    {
        readonly IMessageApplication MessageApplication;

        public MirrorController(IMessageApplication messageApplication)
        {
            MessageApplication = messageApplication;
        }

        [HttpPost]
        public IActionResult Echo(object request)
        {
            return Json(request);
        }

        [Route("Require/{key}/{id}")]
        [HttpPost]
        public IActionResult Require(RequestModel request)
        {
            var stringContent = new StreamContent(HttpContext.Request.Body);
            var httpPostRequest = new HttpPostRequest(request.Id, request.Key, stringContent);
            var responses = MessageApplication.Require(httpPostRequest);

            return Json(responses);
        }
    }
}