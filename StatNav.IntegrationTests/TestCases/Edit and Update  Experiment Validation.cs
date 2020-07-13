using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StatNav.IntegrationTests.PageObjects;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class UpdateExperiments
    {      
        public static void ExperimentUpdateTest()
        {
            Iterations ipage = new Iterations();
            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Experiments")).Click();
            AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[2]/a")).Click();
            string text = ipage.ExperimentName.Text;
            ipage.ExperimentName.SendKeys(text + 1);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            ipage.ExperimentName.Clear();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
           
            bool Experimenterror = AppClass.IsElementPresent(By.XPath("//div[5]/div/span"));
            string Experimenterrortext = AppDriver.driver.FindElement(By.XPath("//div[5]/div/span")).Text;
            Assert.IsTrue(Experimenterror);
            Assert.AreEqual(Experimenterrortext, "The Experiment Name field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
