using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mirror.Web.IntegrationTest
{
    [TestClass]
    public class BasicTests : WebApplicationTestsBase
    {
        [TestMethod]
        public void Pass()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public async Task SqliteDbExist()
        {
            Assert.IsTrue(File.Exists("Mirror.db"));
        }
    }
}