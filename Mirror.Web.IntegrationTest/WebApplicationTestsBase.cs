using System.Net.Http;

namespace Mirror.Web.IntegrationTest
{
    public abstract class WebApplicationTestsBase
    {
        protected readonly HttpClient HttpClient;
        
        public WebApplicationTestsBase()
        {
            var webApplicationFactory = new TestWebApplicationFactory();
            HttpClient = webApplicationFactory.CreateClient();
        }
    }
}