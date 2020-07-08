using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class ValidatePackageContainar
    {      
        public static void PackageContainarMandatoryTest()
        {

            AppDriver.driver.FindElement(By.LinkText("Home")).Click();

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Package Containers")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();

            bool PackageContainerNameerror = AppClass.IsElementPresent(By.XPath("//*[@id='PackageContainerName-error']"));
            string ContainerNameerrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='PackageContainerName-error']")).Text;
            Assert.IsTrue(PackageContainerNameerror);
            Assert.AreEqual(ContainerNameerrortext, "The Package Container Name field is required.");

            bool Typeerror = AppClass.IsElementPresent(By.XPath("//*[@id='Type-error']"));
            string Typeerrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='Type-error']")).Text;
            Assert.IsTrue(Typeerror);
            Assert.AreEqual(Typeerrortext, "The Type field is required.");

            bool MetricModelStageIderror = AppClass.IsElementPresent(By.XPath("//*[@id='MetricModelStageId-error']"));
            string ModelStageIderrortext = AppDriver.driver.FindElement(By.XPath("//*[@id='MetricModelStageId-error']")).Text;
            Assert.IsTrue(MetricModelStageIderror);
            Assert.AreEqual(ModelStageIderrortext, "The Stage field is required.");

            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();
        }
    }
}
