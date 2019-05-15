using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mirror.Web.IntegrationTest
{
    [TestClass]
    public class SystemTests : WebApplicationTestsBase
    {
        [TestMethod]
        [DataRow("/System/Available")]
        public async Task GetRequestSystemApi_MethodNotAllowed(string url)
        {
            var response = await HttpClient.GetAsync(url);

            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        }

        [DataRow("/System/Available", "", "true")]
        public async Task PostRequestSystemApi_ShouldReturnDefaultResponse(string url, string requestContent, string expectedResponseContent)
        {
            var response = await HttpClient.PostAsync(url, new StringContent(null));

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
        }
    }
}