using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class DashboardControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            DashboardController controller = new DashboardController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
