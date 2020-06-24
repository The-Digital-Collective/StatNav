using Applitools;
using Applitools.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Drawing;
using TestAutomationFramework;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace StatNav.IntegrationTests
{
    public class StatNav_VisualTesting
    {
        private EyesRunner runner;
        private Eyes eyes;
        public void StatNavVisualTesting()
        {
         
            try
            {
                string _username = TestContext.Parameters.Get("now");
                string _password = TestContext.Parameters.Get("next");
                string url = TestContext.Parameters.Get("webAppUrl");

                runner = new ClassicRunner();
                eyes = new Eyes(runner);
                eyes.ApiKey = "975LpId103DAQlvQO4qrOra9deeNnZysqfEH4i4EZ48JMA110";

                // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
                eyes.Open(AppDriver.driver, "StatNav", "Visual Test", new Size(800, 600));

                AppDriver.driver.Url = url;
                AppDriver.driver.Manage().Window.Maximize();
                AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

                // Visual checkpoint #1 - Check the login page.
                eyes.CheckWindow("StatNav - Login Page");

                StatNav spage = new StatNav();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Login));

                spage.Login.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSAccount));

                spage.MSAccount.SendKeys(_username);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSPwd));

                spage.MSPwd.SendKeys(_password);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();

                // Visual checkpoint #2 - Check the app page.
                eyes.CheckWindow("StatNav - Home Page");

                AppDriver.driver.FindElement(By.LinkText("Dashboard")).Click();

                // Visual checkpoint #3 - Check the app page.
                eyes.CheckWindow("StatNav - Dashboard");

                AppDriver.driver.FindElement(By.LinkText("Package Containers")).Click();

                // Visual checkpoint #3 - Check the app page.
                eyes.CheckWindow("StatNav - Package Containers");

                AppDriver.driver.FindElement(By.LinkText("Marketing Asset Packages")).Click();

                // Visual checkpoint #3 - Check the app page.
                eyes.CheckWindow("StatNav - Marketing Asset Packages");

                AppDriver.driver.FindElement(By.LinkText("Iterations")).Click();

                // Visual checkpoint #3 - Check the app page.
                eyes.CheckWindow("StatNav - Iterations");

                AppDriver.driver.FindElement(By.LinkText("Candidates")).Click();

                // Visual checkpoint #3 - Check the app page.
                eyes.CheckWindow("StatNav - Candidates");

                // End the test.
                eyes.CloseAsync();

                AppDriver.driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/ul[2]/li[2]/a")).Click();
            }
            finally
            {
                //AppDriver.driver.Quit();

                // If the test was aborted before eyes.close was called, ends the test as aborted.
                eyes.AbortIfNotClosed();

                //Wait and collect all test results
                TestResultsSummary allTestResults = runner.GetAllTestResults();
  
            }
        }
    }
}