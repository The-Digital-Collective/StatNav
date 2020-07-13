using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class ValidateExperiments
    {      
        public static void ExperimentsMandatoryTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Experiments")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            bool AssetPackageerror = AppClass.IsElementPresent(By.XPath("//div/span"));
            string AssetPackagerrortext = AppDriver.driver.FindElement(By.XPath("//div/span")).Text;
            Assert.IsTrue(AssetPackageerror);
            Assert.AreEqual(AssetPackagerrortext, "The Marketing Asset Package field is required.");
            
            bool Experimenterror = AppClass.IsElementPresent(By.XPath("//div[4]/div/span"));
            string Experimenterrortext = AppDriver.driver.FindElement(By.XPath("//div[4]/div/span")).Text;
            Assert.IsTrue(Experimenterror);
            Assert.AreEqual(Experimenterrortext, "The Experiment Name field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
