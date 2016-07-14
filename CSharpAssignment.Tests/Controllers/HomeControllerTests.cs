using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpAssignment.Controllers;

namespace CSharpAssignment.Tests.Controllers
{
    /// <summary>
    /// Summary description for HomeControllerTests
    /// </summary>
    [TestClass]
    public class HomeControllerTests
    {
        HomeController homeController;
        public HomeControllerTests()
        {
            homeController = new HomeController();
        }

        [TestMethod]
        public void About_Tests()
        {
            var result = homeController.About();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact_Tests()
        {
            var result = homeController.Contact();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HomeIndex_Tests()
        {
            var result = homeController.HomeIndex();
            Assert.IsNotNull(result);
        }
    }
}
