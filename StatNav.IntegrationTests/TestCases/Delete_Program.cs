using System;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using TestAutomationFramework;
using StatNav.IntegrationTests.PageObjects;

namespace StatNav.IntegrationTests
{
    public class Delete_Program
    {       
        public static void DeleteProgram(string value)
        {
            AppDriver.test = AppDriver.extent.CreateTest("Delete Program in StatNav App");
            //Utils.CreateFileOrFolder(value);

            ////url To launch the application
            //AppDriver.driver.Url = ConfigurationManager.AppSettings["URL"];
            //    AppDriver.driver.Manage().Window.Maximize();
            //    AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            //    AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

            //    StatNav spage = new StatNav();

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Login));

            //    spage.Login.Click();

            //    // string pp = AppClass.Decrypt(ConfigurationManager.AppSettings["Password"]);

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSAccount));

            //    spage.MSAccount.SendKeys(ConfigurationManager.AppSettings["LoginName"]);

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

            //    spage.MSconfirm.Click();

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSPwd));

            //    spage.MSPwd.SendKeys(ConfigurationManager.AppSettings["Password"]);

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

            //    spage.MSconfirm.Click();

            //    AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.MSconfirm));

            //    spage.MSconfirm.Click();

            //    AppDriver.test.Log(Status.Pass, "Step 1 : Login to the application is Successfull");
            //    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
            //    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step6.png", ScreenshotImageFormat.Png);
            //    AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step6.png").Build());
                StatNav spage = new StatNav();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Programmes));
                spage.Programmes.Click();

                AppDriver.test.Log(Status.Pass, "Step 1 : Navigation successfull to the Programme");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step7.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step7.png").Build());


                AppClass.deleteprogrammethod();

                AppDriver.test.Log(Status.Pass, "Step 2 : All Programmes Deleted Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step8.png", ScreenshotImageFormat.Png);
                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + value + "\\" + "step8.png").Build());

               //AppDriver.driver.Close();

        }
    }
}
