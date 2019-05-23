using System;
using Mirror.Data.Entities;
using Moq;
using NUnit.Framework;

namespace Mirror.UnitTest.Application.Service
{
    public class ActiveVendorTests : IInstanceTesting<ActiveVendor, Vendor>
    {
        [Test]
        public void AdaptFromAndToVendor()
        {
            var vendor = new Vendor
            {
                Url = Guid.NewGuid().ToString()
            };
            var activeVender = new ActiveVendor(vendor);
            var adaptToVender = activeVender.ToAdaptable();

            Assert.AreEqual(vendor.Url, activeVender.Url);
            Assert.AreEqual(activeVender.Url, adaptToVender.Url);
        }

        public ActiveVendor NewTestInstance(Vendor Vendor) => new ActiveVendor(Vendor);
    }
}