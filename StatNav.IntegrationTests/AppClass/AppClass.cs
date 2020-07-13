using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using TestAutomationFramework;
using System.Threading;
using StatNav.IntegrationTests.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using NUnit.Framework;

namespace StatNav.IntegrationTests
{
    public static class AppClass
    {
        public static void StatNavLogin()
        {
            string _username = TestContext.Parameters.Get("now");
            string _password = TestContext.Parameters.Get("next");
            string url = TestContext.Parameters.Get("webAppUrl");              
            AppDriver.driver.Url = url;
            AppDriver.driver.Manage().Window.Maximize();
            AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));
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
        }

        public static void CreatePackageContainer(string containarname, string type, string stage, string notes)
        {
            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Package Containers")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.Id("PackageContainerName")).SendKeys(containarname);
            if (type == "Persistent")
            {
                AppDriver.driver.FindElement(By.Id("Type")).Click();
            }
            else
            {
                AppDriver.driver.FindElement(By.XPath("(//input[@id='Type'])[2]")).Click();
            }
            AppDriver.driver.FindElement(By.Id("MetricModelStageId")).selectdropdowntext(stage);
            AppDriver.driver.FindElement(By.Id("Notes")).SendKeys(notes);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();

            Assert.IsTrue(AppDriver.driver.PageSource.Contains(containarname));
            Assert.IsTrue(AppDriver.driver.PageSource.Contains(type));
            Assert.IsTrue(AppDriver.driver.PageSource.Contains(stage));
        }
        public static void CreateAssetPackage(string MAPname, string ddlcid, string Hypothesis, string Problem,string ProblemValidation, string notes)
        {
            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Marketing Asset Packages")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click();
            AppDriver.driver.FindElement(By.Id("MAPName")).SendKeys(MAPname);
            AppDriver.driver.FindElement(By.Id("PackageContainerId")).selectdropdowntext(ddlcid);
            AppDriver.driver.FindElement(By.Id("Hypothesis")).SendKeys(Hypothesis);
            AppDriver.driver.FindElement(By.Id("Problem")).SendKeys(Problem);
            AppDriver.driver.FindElement(By.Id("ProblemValidation")).SendKeys(ProblemValidation);
            AppDriver.driver.FindElement(By.Id("Notes")).SendKeys(notes);
            AppDriver.driver.FindElement(By.XPath("//input[@value='Save']")).Click();
            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();

            Assert.IsTrue(AppDriver.driver.PageSource.Contains(MAPname));
            Assert.IsTrue(AppDriver.driver.PageSource.Contains(Hypothesis));
        }

        public static void createiteration(string ddlmap,string NewIteration)
        {
            Iterations ipage = new Iterations();
            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Experiments")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click(); 
            AppDriver.driver.FindElement(By.Name("MarketingAssetPackageId")).selectdropdowntext(ddlmap);
            ipage.ExperimentName.SendKeys(NewIteration);
            //ipage.RequiredDurationForSignificance.SendKeys("week");
            //ipage.IterationNumber.SendKeys("10");
            //ipage.StartDateTime.Clear();
            //ipage.StartDateTime.SendKeys("13/04/2017");
            //ipage.EndDateTime.Clear();
            //ipage.EndDateTime.SendKeys("16/12/2019");
            ipage.SuccessOutcome.SendKeys("10");
            ipage.FailureOutcome.SendKeys("5");
            IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
            js.ExecuteScript("javascript:window.scrollBy(0,-250)");
            ipage.SaveExperiment.Click();
            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();

            Assert.IsTrue(AppDriver.driver.PageSource.Contains(NewIteration));
        }

        public static void createcandidate(string ddlit,string Newcandidate)
        {

            Candidate cpage = new Candidate();
            AppDriver.driver.FindElement(By.LinkText("Package Entities")).Click();
            AppDriver.driver.FindElement(By.LinkText("Variants")).Click();
            AppDriver.driver.FindElement(By.LinkText("Create New")).Click(); 
            AppDriver.driver.FindElement(By.Name("ExperimentId")).selectdropdowntext(ddlit);
            cpage.VariantName.SendKeys(Newcandidate);
            cpage.Control.Click();
            cpage.VariantTargetMetricModelId.selectdropdowntext("Basket Adds");
            cpage.TargetMet.Click();
            cpage.VariantImpactMetricModelId.selectdropdowntext("Basket Adds");
            cpage.ImpactMet.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
            js.ExecuteScript("javascript:window.scrollBy(0,-250)");
            cpage.saveVariant.Click();
            AppDriver.driver.FindElement(By.LinkText("Back to List")).Click();

            Assert.IsTrue(AppDriver.driver.PageSource.Contains(Newcandidate));
        }

        public static void deleteprogrammethod()
        {

                var R_elemTable = AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
                // Fetch all Row of the table
                List<IWebElement> R_lstTrElem = new List<IWebElement>(R_elemTable.FindElements(By.TagName("tr")));
                int cnt = R_lstTrElem.Count;
                Console.WriteLine(cnt);
                int i;
                //for (i = 1; i <= cnt-1; i++)
                for (i = 1; i <= cnt-1; i++)
                {
                    var R_elemTable1 = AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
                    var R_elemTr = R_elemTable1.FindElement(By.TagName("tr"));
                    var pp = R_elemTr.FindElement(By.XPath("/html/body/div[2]/table/tbody/tr[2]/td[2]/a"));

                    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(pp));
                    pp.Click();

                    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/a"))));
                    AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div/a")).Click();

                    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/form/input"))));
                    AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/form/input")).Click();

                    Thread.Sleep(2000);
                    R_elemTable1 = null;
                    R_elemTr = null;
                    pp = null;
                }

        }
        public static string Browsername(string Browser)
        {
            string value = Browser.Remove(0, 16);
            string input = value;
            int index = input.IndexOf(".");
            if (index > 0)
                input = input.Substring(0, index);
            return input;
        }

        public static bool IsElementPresent(By by)
        {
            try
            {
                AppDriver.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
