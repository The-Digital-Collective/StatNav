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
            var rand = new Random();
            int val = rand.Next(999999);

            bool isdisplayed = false;

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


                var filepath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName + val}.jpg";

                ((ITakesScreenshot)AppDriver.driver).GetScreenshot().SaveAsFile(filepath);

                TestContext.AddTestAttachment(filepath);

                Console.WriteLine("Login Passed1");          
        }

        public static void createprogramme()
        {
            var rand2 = new Random();
            int val2 = rand2.Next(999999);

            bool isdisplayed = false;
            try
            {

                Programmes ppage = new Programmes();

                ppage.btnCreateNew.Click();
                var rand = new Random();
                int value = rand.Next(999999);
                StatNav spage = new StatNav();
                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Programmes));

                spage.Programmes.Click();

                isdisplayed = spage.Programmes.Displayed;

                ppage.txtProgrammeName.SendKeys("IntegrationTest Programme" + value);

                ppage.txtProblem.SendKeys("IntegrationTest Problem");

                ppage.txtProblemValidation.SendKeys("IntegrationTest validation");

                ppage.txtHypothesis.SendKeys("New");

                ppage.ddlMethod.selectdropdowntext("Randomised Control Trial");

                ppage.ddlTargetMetric.selectdropdowntext("Basket Adds");

                ppage.txtTargetValue.SendKeys("0");

                ppage.ddlImpactMetric.selectdropdowntext("Bounce Rate");

                ppage.txtImpactValue.SendKeys("0");

                ppage.ddlStatus.selectdropdowntext("Draft");

                ppage.txtNotes.SendKeys("Done");

                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                js.ExecuteScript("javascript:window.scrollBy(0,-250)");

                ppage.btnSave.Click();

                Iterations ipage = new Iterations();

                isdisplayed = ipage.Create_Iteration_Link.Displayed;

                var filepath = $"{TestContext.CurrentContext.WorkDirectory}\\{TestContext.CurrentContext.Test.MethodName + val2}.jpg";

                ((ITakesScreenshot)AppDriver.driver).GetScreenshot().SaveAsFile(filepath);

                TestContext.AddTestAttachment(filepath);
                Console.WriteLine("Login passed 2");
            }
            
            catch
            {
                var filepath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName+val2}.jpg";

                ((ITakesScreenshot)AppDriver.driver).GetScreenshot().SaveAsFile(filepath);

                TestContext.AddTestAttachment(filepath);

                Console.WriteLine("Login failed 2");

            }
        }

        public static void createiteration()
        {
 
                Iterations ipage = new Iterations();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(ipage.Create_Iteration_Link));
                ipage.Create_Iteration_Link.Click();


                ipage.IterationName.SendKeys("NewIteration");
                ipage.RequiredDurationForSignificance.SendKeys("week");

                ipage.IterationNumber.SendKeys("10");
                ipage.StartDateTime.Clear();
                ipage.StartDateTime.SendKeys("13/04/2017");
                ipage.EndDateTime.Clear();
                ipage.EndDateTime.SendKeys("16/12/2019");
                ipage.SuccessOutcome.SendKeys("10");
                ipage.FailureOutcome.SendKeys("5");
                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                js.ExecuteScript("javascript:window.scrollBy(0,-250)");
                ipage.SaveCandidate.Click();
                ipage.Create_Candidate.Click();
        }

        public static void createcandidate()
        {

                Candidate cpage = new Candidate();

                cpage.CandidateName.SendKeys("Newcandidate");
                cpage.Control.Click();

                cpage.CandidateTargetMetricModelId.selectdropdowntext("Basket Adds");
                cpage.TargetMet.Click();

                cpage.CandidateImpactMetricModelId.selectdropdowntext("Basket Adds");
                cpage.ImpactMet.Click();

                IJavaScriptExecutor js = (IJavaScriptExecutor)AppDriver.driver;
                js.ExecuteScript("javascript:window.scrollBy(0,-250)");
                cpage.savecandidate.Click();
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
    }
}
