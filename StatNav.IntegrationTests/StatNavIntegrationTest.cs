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
    //[TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(InternetExplorerDriver))]
   
    public class StatNavIntegrationTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        [OneTimeSetUp]
        public void Initialization()
        {
            Utils.DriverSetup();
            AppDriver.driver = new TWebDriver();

        }

        [Test, Order(1)]
        public void VisualTest()
        {
            StatNav_VisualTesting vt = new StatNav_VisualTesting();
            vt.StatNavVisualTesting();
        }

        [Test,Order(2)]
        public void CreateProgram()
        {
            Create_Program.CreateProgram();

        }

        [Test,Order(3)]
        public void DeletePrgrammes()
        {
            Delete_Program.DeleteProgram();

        }



        [OneTimeTearDown]
        public void Browser()
        {
            AppDriver.driver.Close();
        }
    }
}




