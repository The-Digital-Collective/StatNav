using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class UpdateMarketingAsset
    {      
        public static void MarketingAssetUpdateTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Marketing Asset Packages")).Click();
            AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]/a")).Click();

            string text = AppDriver.driver.FindElement(By.Id("MAPName")).Text;
            AppDriver.driver.FindElement(By.Id("MAPName")).SendKeys(text +1);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            AppDriver.driver.FindElement(By.Id("MAPName")).Clear();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            bool MAPNameerror = AppClass.IsElementPresent(By.XPath("//*[@id='MAPName-error']"));
            string MAPrNameerrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='MAPName-error']")).Text;
            Assert.IsTrue(MAPNameerror);
            Assert.AreEqual(MAPrNameerrortext, "The Package Name field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
