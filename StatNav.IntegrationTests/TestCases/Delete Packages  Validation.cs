using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class DeletePackages
    {      
        public static void DeletePackagesTest()
        {
            AppDriver.driver.FindElement(By.LinkText("Home")).Click();
            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Package Containers")).Click();
            AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]/a"))));
            string value = AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]/a")).Text;
            AppDriver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]/a")).Click();
            AppDriver.driver.FindElement(By.LinkText("Delete")).Click();//html/body/div[3]/div[1]/text()
            //string warningtext = AppDriver.driver.FindElement(By.XPath("//div[3]/div[1]")).GetAttribute();
            //Assert.AreEqual(warningtext, "Are you sure you want to remove this Package Container? Removing this package will also remove all its marketing asset packages, experiments and variants");
            AppDriver.driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsFalse(AppDriver.driver.PageSource.Contains(value));
        }
    }
}
