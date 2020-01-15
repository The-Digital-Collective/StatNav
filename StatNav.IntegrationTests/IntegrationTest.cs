using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace StatNav.IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        private string _webSiteUrl = "https://www.worldvision.org.uk/";
        private RemoteWebDriver _browserDriver;
        public TestContext TestContext { get; set; }

        [TestInitialize()]
        public void Initialize()
        {
            //Override the default webSiteUrl with the value held against the variable "statNavUrl" in the
            //DevOps release pipeline variable list
            //_webSiteUrl = (string)TestContext.Properties["statNavUrl"];
            _browserDriver = new ChromeDriver();
            _webSiteUrl = (string)TestContext.Properties["webAppUrl"];
        }


        [TestMethod]
        [TestCategory("Selenium")]
        [DataRow("Programme 1", "Number 1 Problem Description", "Number 1 Problem Validation", "1", "1", "Draft")]
        [DataRow("Programme 2", "Number 2 Problem Description", "Number 2 Problem Validation", "1", "2", "Scheduled")]
        [DataRow("Programme 3", "Number 3 Problem Description", "Number 3 Problem Validation", "1", "3", "Live")]

        // Add test input data here
        public void CreateProgramme(string Name, string Problem, string ProblemValidation, string TargetMetricModelId, string ExperimentStatusId, string ExperimentStatusName)
        {

            _browserDriver.Navigate().GoToUrl(_webSiteUrl + "Programme/Create");
            _browserDriver.Manage().Window.Maximize();


            _browserDriver.FindElementById("Name").Clear();
            _browserDriver.FindElementById("Name").SendKeys(Name);

            _browserDriver.FindElementById("Problem").Clear();
            _browserDriver.FindElementById("Problem").SendKeys(Problem);

            _browserDriver.FindElementById("ProblemValidation").Clear();
            _browserDriver.FindElementById("ProblemValidation").SendKeys(ProblemValidation);

            IWebElement ddlTargetMetricModelId = _browserDriver.FindElement(By.Name("TargetMetricModelId"));
            IList<IWebElement> tmmselectElements = _browserDriver.FindElements(By.Name("TargetMetricModelId"));
            foreach (IWebElement item in tmmselectElements)
            {
                SelectElement elements = new SelectElement(item);
                elements.SelectByValue(TargetMetricModelId);

            }

            IWebElement ddlExperimentStatusId = _browserDriver.FindElement(By.Name("ExperimentStatusId"));
            IList<IWebElement> seselectElements = _browserDriver.FindElements(By.Name("ExperimentStatusId"));
            foreach (IWebElement item in seselectElements)
            {
                SelectElement elements = new SelectElement(item);
                elements.SelectByValue(ExperimentStatusId);

            }
            IWebElement submitButton = _browserDriver.FindElement(By.Id("btnSubmit"));
            //need to scroll back to top of page to get to submit button
            IJavaScriptExecutor je = _browserDriver;
            je.ExecuteScript("arguments[0].scrollIntoView(false);", submitButton);
            submitButton.Click();

            Assert.IsTrue(_browserDriver.PageSource.Contains(Name));
            Assert.IsTrue(_browserDriver.PageSource.Contains(Problem));
            Assert.IsTrue(_browserDriver.PageSource.Contains(ExperimentStatusName));
        }

        [TestCleanup()]
        public void CleanUp()
        {
            _browserDriver.Quit();
        }

    }
}
