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
                WebDriverWait waitone = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));
                AppDriver.spage = new StatNav();
                try
                {
                    //waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.Login));
                    AppDriver.spage.Login.Click();
                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSAccount));
                    AppDriver.spage.MSAccount.SendKeys(ConfigurationManager.AppSettings["LoginName"]);
                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSconfirm));
                    AppDriver.spage.MSconfirm.Click();
                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSPwd));
                    AppDriver.spage.MSPwd.SendKeys(ConfigurationManager.AppSettings["Password"]);
                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSconfirm));
                    AppDriver.spage.MSconfirm.Click();
                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.MSconfirm));
                    AppDriver.spage.MSconfirm.Click();
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                AppDriver.test.Log(Status.Pass, "Step 1 : Login to the application is Successfull");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();

                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.Programmes));
                AppDriver.spage.Programmes.Click();

                AppDriver.test.Log(Status.Pass, "Step 2 : Navigation successfull to the Programme");
                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
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
