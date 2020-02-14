using System;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace StatNav.IntegrationTests
{
    public class Delete_Program
    {       
        public static void DeleteProgram()
        {

            try
            {
                //url To launch the application
                AppDriver.driver.Url = ConfigurationManager.AppSettings["URL"];
                AppDriver.driver.Manage().Window.Maximize();
                AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
                AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

                AppClass.StatNavLogin();

                AppDriver.test.Log(Status.Pass, "Step 1 : Login to the application is Successfull");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();

                AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.Programmes));
                AppDriver.spage.Programmes.Click();

                AppDriver.test.Log(Status.Pass, "Step 2 : Navigation successfull to the Programme");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();

                AppClass.deleteprogrammethod();

                AppDriver.test.Log(Status.Pass, "Step 3 : All Programmes Deleted Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.driver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                AppDriver.test.Log(Status.Fail, "Step End : Execution Failed "+e);
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.driver.Close();
            }
        }
    }
}
