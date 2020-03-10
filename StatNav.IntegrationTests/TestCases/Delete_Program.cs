using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public class Delete_Program
    {       
        public static void DeleteProgram()
        {

            StatNav spage = new StatNav();

            AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Programmes));
            spage.Programmes.Click();

            try
            {
                IAlert aler = AppDriver.driver.SwitchTo().Alert();
                aler.Accept();
            }
            catch (NoAlertPresentException ex)
            {
                ex.Message.ToString();
            }

            AppDriver.wait.Until(ExpectedConditions.ElementToBeClickable(spage.Programmes));
            spage.Programmes.Click();

            AppClass.deleteprogrammethod();

            spage.Logout.Click();

        }
    }
}
