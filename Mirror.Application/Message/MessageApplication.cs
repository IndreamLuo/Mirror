using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mirror.Application.Message.Requests;
using Mirror.Application.Message.Responses;
using Mirror.Application.Service;

namespace Mirror.Application.Message
{
    public class MessageApplication : IMessageApplication
    {
        readonly IServiceManager ServiceManager;
        readonly HttpClient HttpClient;

        public MessageApplication(IServiceManager serviceManager, HttpClient httpClient)
        {
            ServiceManager = serviceManager;
            HttpClient = httpClient;
        }

        public IEnumerable<Response> Require(Request request)
        {
            var service = ServiceManager[request.Key];

            var responses = service
                .Vendors
                .Select(vendor =>
                {
                    var httpContent = (request as HttpPostRequest).HttpContent;
                    var response = HttpClient.PostAsync(vendor.Url, httpContent).Result;
                    return new HttpResponse(request, response) as Response;
                });

            return responses;
        }
    }
}