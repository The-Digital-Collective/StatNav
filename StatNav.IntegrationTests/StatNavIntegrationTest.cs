using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace StatNav.IntegrationTests
{
  //  [TestFixture(typeof(FirefoxDriver))]
   // [TestFixture(typeof(ChromeDriver))]
   // [TestFixture(typeof(InternetExplorerDriver))]
    public class StatNavIntegrationTest
    {
       
        [SetUp]
        public void Initialization()
        {
            Utils.DriverSetup();
            //Utils.Extent_Test(ConfigurationManager.AppSettings["ReportsPath"]+"Execution_Report.html");
            Utils.Extent_Test("C:\\Users\\ramkumar.r\\Desktop\\World Vision\\Execution_Report.html");
        }

        [Test]
        public void Program()
        {
            AppDriver.test = AppDriver.extent.CreateTest("Create Program");
            AppDriver.driver = new ChromeDriver();
            Create_Program.CreateProgram();
            AppDriver.test = AppDriver.extent.CreateTest("Delete Program");
            AppDriver.driver = new ChromeDriver();
            Delete_Program.DeleteProgram();
        }

        [TearDown]
        public void closeBrowser()
        {
            AppDriver.extent.Flush();           
        }
    }

}




