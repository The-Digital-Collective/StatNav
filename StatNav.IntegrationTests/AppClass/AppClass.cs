using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using StatNav.IntegrationTests.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace StatNav.IntegrationTests
{
    class AppClass
    {
        public static void StatNavLogin()
        {
            AppDriver.spage = new StatNav();
            try
            {
                AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

                AppDriver.spage.Login.Click();

                AppDriver.spage.MSAccount.SendKeys(ConfigurationManager.AppSettings["LoginName"]);

                AppDriver.spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSPwd));

                AppDriver.spage.MSPwd.SendKeys(ConfigurationManager.AppSettings["Password"]);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSconfirm));

                AppDriver.spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSconfirm));

                AppDriver.spage.MSconfirm.Click();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void createprogrammethod()
        {

            AppDriver.ppage = new Programmes();
            try
            {
                AppDriver.ppage.btnCreateNew.Click();
                var rand = new Random();
                int value = rand.Next(999999);
                //string text = value.ToString("000");

                AppDriver.ppage.txtProgrammeName.SendKeys("IntegrationTest Programme" + value);

                AppDriver.ppage.txtProblem.SendKeys("IntegrationTest Problem");

                AppDriver.ppage.txtProblemValidation.SendKeys("IntegrationTest validation");

                AppDriver.ppage.txtHypothesis.SendKeys("New");

                AppDriver.ppage.ddlMethod.selectdropdowntext("Randomised Control Trial");

                AppDriver.ppage.ddlTargetMetric.selectdropdowntext("Basket Adds");

                AppDriver.ppage.txtTargetValue.SendKeys("0");

                AppDriver.ppage.ddlImpactMetric.selectdropdowntext("Bounce Rate");

                AppDriver.ppage.txtImpactValue.SendKeys("0");

                AppDriver.ppage.ddlStatus.selectdropdowntext("Draft");

                AppDriver.ppage.txtNotes.SendKeys("Done");

                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                js.ExecuteScript("javascript:window.scrollBy(0,-250)");

                AppDriver.ppage.btnSave.Click();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void createiteration()
        {
            try
            {
                AppDriver.ipage = new Iterations();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.ipage.Create_Iteration_Link));
                AppDriver.ipage.Create_Iteration_Link.Click();


                AppDriver.ipage.IterationName.SendKeys("NewIteration");
                AppDriver.ipage.RequiredDurationForSignificance.SendKeys("week");

                AppDriver.ipage.IterationNumber.SendKeys("10");
                AppDriver.ipage.StartDateTime.SendKeys("13/04/2017");
                AppDriver.ipage.EndDateTime.SendKeys("16/12/2019");
                AppDriver.ipage.SuccessOutcome.SendKeys("10");
                AppDriver.ipage.FailureOutcome.SendKeys("5");
                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                js.ExecuteScript("javascript:window.scrollBy(0,-250)");
                AppDriver.ipage.SaveCandidate.Click();
                AppDriver.ipage.Create_Candidate.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        //public static void createcandidate()
        //{
        //    try
        //    {
        //        AppDriver.cpage = new Candidate();

        //        AppDriver.cpage.CandidateName.SendKeys("Newcandidate");
        //        AppDriver.cpage.Control.Click();

        //        AppDriver.cpage.CandidateTargetMetricModelId.selectdropdowntext("Basket Adds");
        //        AppDriver.cpage.TargetMet.Click();

        //        AppDriver.cpage.CandidateImpactMetricModelId.selectdropdowntext("Basket Adds");
        //        AppDriver.cpage.ImpactMet.Click();

        //        IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
        //        js.ExecuteScript("javascript:window.scrollBy(0,-250)");
        //        AppDriver.cpage.savecandidate.Click();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        public static void deleteprogrammethod()
        {
            try
            {
                var R_elemTable = AppDriver.driver.FindElement(By.XPath("/html/body/div[2]/table/tbody"));
                // Fetch all Row of the table
                List<IWebElement> R_lstTrElem = new List<IWebElement>(R_elemTable.FindElements(By.TagName("tr")));
                int cnt = R_lstTrElem.Count;
                Console.WriteLine(cnt);
                int i;
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
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

}
