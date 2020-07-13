using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class ValidateMarketingAsset
    {      
        public static void MarketingAssetMandatoryTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Marketing Asset Packages")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            
            bool MAPNameerror = AppClass.IsElementPresent(By.XPath("//*[@id='MAPName-error']"));
            string MAPrNameerrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='MAPName-error']")).Text;
            Assert.IsTrue(MAPNameerror);
            Assert.AreEqual(MAPrNameerrortext, "The Package Name field is required.");

            bool ContainerIderror = AppClass.IsElementPresent(By.XPath("//*[@id='PackageContainerId-error']"));
            string ContainerIderrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='PackageContainerId-error']")).Text;
            Assert.IsTrue(ContainerIderror);
            Assert.AreEqual(ContainerIderrortext, "The Container field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
