using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StatNav.IntegrationTests.PageObjects;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class UpdateVariant
    {      
        public static void VariantUpdateTest()
        {
            Candidate cpage = new Candidate();
            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Variants")).Click();
            AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[2]/a")).Click();
            string text = cpage.VariantName.Text;
            cpage.VariantName.SendKeys(text+1);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            cpage.VariantName.Clear();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            bool Variantnameerror = AppClass.IsElementPresent(By.XPath("//div[5]/div/span"));
            string Variantnameerrortext = AppDriver.driver.FindElement(By.XPath("//div[5]/div/span")).Text;
            Assert.IsTrue(Variantnameerror);
            Assert.AreEqual(Variantnameerrortext, "The Variant Name field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
