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

        [OneTimeSetUp]
        public void Initialization()
        {

            Utils.DriverSetup();
            AppDriver.driver = new TWebDriver();
            string Browser = Convert.ToString(AppDriver.driver);
            string value = AppClass.Browsername(Browser);
            Utils.Extent_Test(ConfigurationManager.AppSettings["ReportsPath"] + value + " Test Report.html");
        }

        [OneTimeTearDown]
        public void Browser()
        {
            AppDriver.extent.Flush();
        }

        [Test]
        public void Program()
        {
            string Browser = Convert.ToString(AppDriver.driver);
            string value = AppClass.Browsername(Browser);
            Create_Program.CreateProgram(value);
            //Delete_Program.DeleteProgram(value);
            AppDriver.driver.Close();
        }
    }
}




