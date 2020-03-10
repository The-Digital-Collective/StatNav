using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
   
    public class StatNavIntegrationTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private string _webSiteUrl = "https://www.worldvision.org.uk/";
        //private RemoteWebDriver _browserDriver;
        public TestContext TestContext { get; set; }


        [OneTimeSetUp]
        public void Initialization()
        {

            Utils.DriverSetup();
            AppDriver.driver = new TWebDriver();
            string Browser = Convert.ToString(AppDriver.driver);
            string value = AppClass.Browsername(Browser);
            Utils.Extent_Test(ConfigurationManager.AppSettings["ReportsPath"] + value + " Test Report.html");
            Utils.CreateFileOrFolder(value);
            foreach (var name in TestContext.Parameters.Names)
            {
                Console.WriteLine("Parameter: {0} = {1}", name, TestContext.Parameters.Get(name));
            }

        }     

        [Test,Order(1)]
        public void Program()
        {
            string Browser = Convert.ToString(AppDriver.driver);
            string value = AppClass.Browsername(Browser);
         
            Create_Program.CreateProgram(value);

        }

        [Test,Order(2)]
        public void Delete()
        {
            string Browser = Convert.ToString(AppDriver.driver);
            string value = AppClass.Browsername(Browser);

            Delete_Program.DeleteProgram(value);
            AppDriver.driver.Close();
        }

        [OneTimeTearDown]
        public void Browser()
        {
            AppDriver.extent.Flush();
            //Utils.DriverSetup();
            //AppClass.SendMail();
        }
    }
}




