using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class UpdatePackageContainar
    {      
        public static void PackageContainarUpdateTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Package Containers")).Click();
            AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]/a")).Click();

            string text = AppDriver.driver.FindElement(By.Id("PackageContainerName")).Text;
            AppDriver.driver.FindElement(By.Id("PackageContainerName")).SendKeys(text +1);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            AppDriver.driver.FindElement(By.Id("PackageContainerName")).Clear();

            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            bool PackageContainerNameerror = AppClass.IsElementPresent(By.XPath("//*[@id='PackageContainerName-error']"));
            string ContainerNameerrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='PackageContainerName-error']")).Text;
            Assert.IsTrue(PackageContainerNameerror);
            Assert.AreEqual(ContainerNameerrortext, "The Package Container Name field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
