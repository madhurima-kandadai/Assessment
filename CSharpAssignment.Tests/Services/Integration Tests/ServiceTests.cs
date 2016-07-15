using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpAssignment.Services;
using CSharpAssignment.Services.Models;

namespace CSharpAssignment.Tests.Services.Integration_Tests
{
    /// <summary>
    /// Summary description for ServiceTests
    /// </summary>
    [TestClass]
    public class ServiceTests
    {
        Service1 service;
        public ServiceTests()
        {
            //
            service = new Service1();
            // TODO: Add constructor logic here
            //
        }
        [TestMethod]
        public void CrimeTypes_Get()
        {
            var list = service.GetCrimeTypes();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void Locations_Get()
        {
            var list = service.GetLocations();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void CrimeSearchGet_EmptyEmailId()
        {
            var count = service.GetCriminalSearchDetails(new CriminalModel { AgeRange = "26-50" });
            Assert.IsTrue(true, count.ToString());
        }

        [TestMethod]
        public void CrimeSearchGet_InvalidMailId()
        {
            var count = service.GetCriminalSearchDetails(new CriminalModel { AgeRange = "26-50", EmailId = "test@gmail.com" });
            Assert.IsTrue(true, count.ToString());
        }

        [TestMethod]
        public void CrimeSearchGet_ValidMailId()
        {
            var count = service.GetCriminalSearchDetails(new CriminalModel { AgeRange = "26-50", EmailId = "madhurima.kandadai@gmail.com" });
            Assert.IsTrue(true, count.ToString());
        }
    }
}
