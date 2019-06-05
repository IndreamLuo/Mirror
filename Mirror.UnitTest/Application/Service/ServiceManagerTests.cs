using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mirror.Application.Service;
using Mirror.Data;
using Mirror.Data.Entities;
using Mirror.UnitTest.Mock.Data;
using Moq;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Service
{
    public class ServiceManagerTests
    {
        [Test]
        public void GetServiceByKey()
        {
            var mocks = Mock.Mocks.New();
            var servicesMock = mocks
                .NewDbSet<Data.Entities.Service>()
                .IsEnumerable(new []
                {
                    new Data.Entities.Service
                    {
                        Key = "TestKey",
                        Name = "TestName"
                    }
                });

            var dbContextMock = mocks
                .NewDbContext<MirrorDbContext>()
                .WithDbSet(context => context.Services, servicesMock.Object);

            var serviceManager = new ServiceManager(dbContextMock.Object);
            var service = serviceManager["TestKey"];

            Assert.AreEqual("TestName", service.Name);
            mocks.VerifyAll();
        }

        [Test]
        public void GetServices()
        {
            var mocks = Mock.Mocks.New();

            var servicesMock = new Mock<DbSet<Data.Entities.Service>>();
            var dbContextMock = mocks
                .NewDbContext<MirrorDbContext>()
                .WithDbSet(context => context.Services, servicesMock.Object);

            var serviceManager = new ServiceManager(dbContextMock.Object);

            var services = serviceManager.Services;

            Assert.AreEqual(servicesMock.Object, services);
            mocks.VerifyAll();
        }

        [Test]
        public void AddService()
        {
            var mocks = Mock.Mocks.New();

            var services = new List<Data.Entities.Service>
            {
                new Data.Entities.Service
                {
                    Key = "Test1"
                }
            };

            Assert.AreEqual(1, services.Count());

            var servicesMock = mocks
                .NewDbSet<Data.Entities.Service>()
                .CanAddTo(services);

            var dbContextMock = mocks
                .NewDbContext<MirrorDbContext>()
                .WithDbSet(context => context.Services, servicesMock.Object)
                .SavedChanges();

            var serviceManager = new ServiceManager(dbContextMock.Object);
            serviceManager.AddService(new Data.Entities.Service
            {
                Key = "Test2"
            });

            Assert.AreEqual(2, services.Count());
            mocks.VerifyAll();
        }

        [Test]
        public void AddVendor()
        {
            var mocks = Mock.Mocks.New();

            var vendors = new List<Vendor>();

            var servicesMock = mocks
                .NewDbSet<Data.Entities.Service>()
                .IsEnumerable(new []
                {
                    new Data.Entities.Service
                    {
                        Key = "TestKey",
                        Vendors = vendors
                    }
                });
            
            var dbContextMock = mocks
                .NewDbContext<MirrorDbContext>()
                .WithDbSet(context => context.Services, servicesMock.Object)
                .SavedChanges();
            
            var serviceManager = new ServiceManager(dbContextMock.Object);
            serviceManager.AddVendor("TestKey", new Vendor
            {
                Url = "TestUrl"
            });

            Assert.AreEqual(1, vendors.Count);
            mocks.VerifyAll();
        }
    }
}