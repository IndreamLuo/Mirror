using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mirror.Application.Service;
using Mirror.Data;
using Moq;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Service
{
    public class ServiceApplicationTests
    {
        [Test]
        public void GetServiceByKey()
        {
            var servicesMock = new Mock<DbSet<Data.Entities.Service>>();
            var queryable = new List<Data.Entities.Service>
            {
                new Data.Entities.Service
                {
                    Key = "TestKey",
                    Name = "TestName"
                }
            }.AsQueryable();
            servicesMock.As<IQueryable<Data.Entities.Service>>().Setup(m => m.Provider).Returns(queryable.Provider);
            servicesMock.As<IQueryable<Data.Entities.Service>>().Setup(m => m.Expression).Returns(queryable.Expression);
            servicesMock.As<IQueryable<Data.Entities.Service>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            servicesMock.As<IQueryable<Data.Entities.Service>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            var dbContextMock = new Mock<MirrorDbContext>();
            dbContextMock.Setup(context => context.Services).Returns(servicesMock.Object);

            var serviceManager = new ServiceManager(dbContextMock.Object);
            var service = serviceManager["TestKey"];

            Assert.AreEqual("TestName", service.Name);
        }

        [Test]
        public void GetServices()
        {
            var servicesMock = new Mock<DbSet<Data.Entities.Service>>();
            var dbContextMock = new Mock<MirrorDbContext>();
            dbContextMock.Setup(context => context.Services).Returns(servicesMock.Object);

            var serviceManager = new ServiceManager(dbContextMock.Object);

            var services = serviceManager.Services;

            Assert.AreEqual(servicesMock.Object, services);
        }
    }
}