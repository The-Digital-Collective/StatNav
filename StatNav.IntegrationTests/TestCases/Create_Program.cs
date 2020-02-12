using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using StatNav.IntegrationTests.PageObjects;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace StatNav.IntegrationTests
{
    public class Create_Program
    {        
        public static void CreateProgram()
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

               
                AppClass.createprogrammethod();


                AppDriver.test.Log(Status.Pass, "Step 3 : Programme created Successfully");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();

                //AppDriver.ipage = new Iterations();

                //AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.ipage.Create_Iteration_Link));
                //AppDriver.ipage.Create_Iteration_Link.Click();
                //AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(AppDriver.ipage.ddlExperimentProgrammeId));
                //AppDriver.ipage.ddlExperimentProgrammeId.selectdropdowntext("Email Marketing Programme");

                AppDriver.driver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                AppDriver.test.Log(Status.Fail, "Step End : Execution Failed ");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
                AppDriver.driver.Close();
            }
        }
    }
}
