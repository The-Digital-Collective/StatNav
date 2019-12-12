using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace StatNav.IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        private string webSiteUrl = "https://www.worldvision.org.uk/";
        private RemoteWebDriver browserDriver;
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void Initialize()
        {
            //Override the default webSiteUrl with the value held against the variable "statNavUrl" in the
            //DevOps release pipeline variable list
            webSiteUrl = (string)TestContext.Properties["statNavUrl"];
        }

        [TestMethod]
        [TestCategory("Selenium")]
        // Add test input data here
        public void ChromeTestMethod()
        {
            browserDriver = new ChromeDriver();

            //Add Selenium integration tests here
        }

    }
}
