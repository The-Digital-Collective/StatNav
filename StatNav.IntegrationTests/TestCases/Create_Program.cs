using System;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium;
using TestAutomationFramework;
using AventStack.ExtentReports;
using NUnit.Framework;

namespace StatNav.IntegrationTests
{
    public class Create_Program
    {        
        public static void CreateProgram(string value)
        {
            AppDriver.test = AppDriver.extent.CreateTest("Create Program in StatNav App");
            Utils.CreateFileOrFolder(value);
            
            try
            {
                //string pp1 = AppClass.Encrypt(ConfigurationManager.AppSettings["Password"]);
                //string pp = AppClass.Decrypt(pp1);

                //url To launch the application
                AppDriver.driver.Url = ConfigurationManager.AppSettings["URL"];
                AppDriver.driver.Manage().Window.Maximize();
                AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

                StatNav spage = new StatNav();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Login));

                spage.Login.Click();

                // string pp = AppClass.Decrypt(ConfigurationManager.AppSettings["Password"]);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSAccount));

                spage.MSAccount.SendKeys(ConfigurationManager.AppSettings["LoginName"]);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSPwd));

                spage.MSPwd.SendKeys(ConfigurationManager.AppSettings["Password"]);

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

                spage.MSconfirm.Click();


                AppDriver.test.Log(Status.Pass, "Step 1 : Login to the application is Successfull");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step1.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step1.png").Build());

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Programmes));
                spage.Programmes.Click();

                AppDriver.test.Log(Status.Pass, "Step 2 : Navigation successfull to the Programme");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step2.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step2.png").Build());

                AppClass.createprogramme();

                AppDriver.test.Log(Status.Pass, "Step 3 : Programme created Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step3.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step3.png").Build());

                AppClass.createiteration();

                AppDriver.test.Log(Status.Pass, "Step 4 : Iteration created Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step4.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step4.png").Build());

                AppClass.createcandidate();


                AppDriver.test.Log(Status.Pass, "Step 5 : Candidate created Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step5.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step5.png").Build());

                AppDriver.driver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                AppDriver.test.Log(Status.Fail, "Step End : Execution Failed ");
                AppDriver.driver.Close();
            }
        }
    }
}
