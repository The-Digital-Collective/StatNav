using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests.TestCases
{
    public static class ValidateHeaderMenu
    {
        public static void ValidateHeaderMenuTest()
        {
            bool Home = AppClass.IsElementPresent(By.LinkText("Home"));
            Assert.IsTrue(Home);
            bool Dashboard = AppClass.IsElementPresent(By.LinkText("Dashboard"));
            Assert.IsTrue(Dashboard);
            bool Username = AppClass.IsElementPresent(By.XPath("//ul[2]/li"));
            Assert.IsTrue(Username);
            bool Signout = AppClass.IsElementPresent(By.LinkText("Sign out"));
            Assert.IsTrue(Signout);
            bool Package_Entities = AppClass.IsElementPresent(By.LinkText("Package Entities"));
            Assert.IsTrue(Package_Entities);

            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            bool PackageContainers = AppClass.IsElementPresent(By.LinkText("Package Containers"));
            Assert.IsTrue(PackageContainers);
            bool MarketingAssetPackages = AppClass.IsElementPresent(By.LinkText("Marketing Asset Packages"));
            Assert.IsTrue(MarketingAssetPackages);
            bool Variants = AppClass.IsElementPresent(By.LinkText("Variants"));
            Assert.IsTrue(Variants);
            bool Experiments = AppClass.IsElementPresent(By.LinkText("Experiments"));
            Assert.IsTrue(Experiments);
        }
    }
}
