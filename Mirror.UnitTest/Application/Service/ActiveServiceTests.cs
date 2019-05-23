using System.Linq;
using Mirror.Application.Service;
using Mirror.Data.Entities;
using Moq;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Service
{
    public class ActiveServiceTests : IInstanceTesting<ActiveService, Data.Entities.Service>
    {
        [Test]
        public void AdaptFromService()
        {
            var service = NewTestService();
            var activeService = NewTestInstance(service);

            Assert.AreEqual(service.Key, activeService.Key);
            Assert.AreEqual(service.Name, activeService.Name);
            Assert.AreEqual(service.Description, activeService.Description);
            Assert.AreEqual(service.Vendors.First().Url, activeService.Vendors.First().Url);
            Assert.AreEqual(service.Vendors.Last().Url, activeService.Vendors.Last().Url);
        }

        [Test]
        public void ToAdaptable()
        {
            var activeService = NewTestInstance(NewTestService());
            var service = activeService.ToAdaptable();

            Assert.AreEqual(service.Key, activeService.Key);
            Assert.AreEqual(service.Name, activeService.Name);
            Assert.AreEqual(service.Description, activeService.Description);
            Assert.AreEqual(service.Vendors.First().Url, activeService.Vendors.First().Url);
            Assert.AreEqual(service.Vendors.Last().Url, activeService.Vendors.Last().Url);
        }

        public ActiveService NewTestInstance(Data.Entities.Service service) => new ActiveService(service);

        public Data.Entities.Service NewTestService() => new Data.Entities.Service
        {
            Id = 2019,
            Key = "MyKey",
            Name = "MyName",
            Description = "MyDescription",
            Vendors = new []
            {
                new Vendor
                {
                    Id = 2020,
                    Url = "https://www.test1.com"
                },
                new Vendor
                {
                    Id = 2021,
                    Url = "https://www.test2.com"
                }
            }
        };
    }
}