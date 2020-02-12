using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace StatNav.IntegrationTests
{
  //  [TestFixture(typeof(FirefoxDriver))]
   // [TestFixture(typeof(ChromeDriver))]
   // [TestFixture(typeof(InternetExplorerDriver))]
    public class Create_Programs
    {
       
        [SetUp]
        public void Initialization()
        {
            Utils.DriverSetup();
            Utils.Extent_Test("C:\\Users\\ramkumar.r\\Desktop\\World Vision\\Execution_Report.html");
        }

        [Test]
        public void Program_FirefoxTest()
        {
            AppDriver.test = AppDriver.extent.CreateTest("Create Program in Chrome");
            AppDriver.driver = new ChromeDriver();
            Create_Program.CreateProgram();
            //Delete_Program.DeleteProgram();
        }

        [TearDown]
        public void closeBrowser()
        {
            AppDriver.extent.Flush();           
        }
    }

}




