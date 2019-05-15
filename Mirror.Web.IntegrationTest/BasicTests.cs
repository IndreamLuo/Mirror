using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mirror.Web.IntegrationTest
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void Pass()
        {
            Assert.IsNull(null);
        }
    }
}