using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class ValidateVariant
    {      
        public static void VariantMandatoryTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Variants")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            
            bool ExperoiementNameerror = AppClass.IsElementPresent(By.XPath("//div/span"));
            string Experoiementerrortext = AppDriver.driver.FindElement(By.XPath("//div/span")).Text;
            Assert.IsTrue(ExperoiementNameerror);
            Assert.AreEqual(Experoiementerrortext, "The Experiment field is required.");

            bool Variantnameerror = AppClass.IsElementPresent(By.XPath("//div[4]/div/span"));
            string Variantnameerrortext = AppDriver.driver.FindElement(By.XPath("//div[4]/div/span")).Text;
            Assert.IsTrue(Variantnameerror);
            Assert.AreEqual(Variantnameerrortext, "The Variant Name field is required.");

            bool TargetMetricerror = AppClass.IsElementPresent(By.XPath("//div[6]/div/span"));
            string TargetMetricerrortext = AppDriver.driver.FindElement(By.XPath("//div[6]/div/span")).Text;
            Assert.IsTrue(TargetMetricerror);
            Assert.AreEqual(TargetMetricerrortext, "The Target Metric field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
