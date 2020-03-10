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
        public static void CreateProgram()
        {
            string url = TestContext.Parameters.Get("webAppUrl");
            //url To launch the application
            AppDriver.driver.Url = url;
            AppDriver.driver.Manage().Window.Maximize();
            AppDriver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            AppDriver.wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

            AppClass.StatNavLogin();

            var filepath = $"{TestContext.CurrentContext.TestDirectory}\\{TestContext.CurrentContext.Test.MethodName}.jpg";

            ((ITakesScreenshot)AppDriver.driver).GetScreenshot().SaveAsFile(filepath);

            TestContext.AddTestAttachment(filepath);

            AppClass.createprogramme();

            AppClass.createiteration();

            AppClass.createcandidate();
        }
    }
}
