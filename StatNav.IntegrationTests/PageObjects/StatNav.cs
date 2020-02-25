using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using StatNav.IntegrationTests;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    class StatNav
    {
        public StatNav()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign out")]
        public IWebElement Logout { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//*[@id='i0116']")]
        public IWebElement MSAccount { get; set; } //*[@id="i0116"]

        [FindsBy(How = How.XPath, Using = "//*[@id='i0118']")]
        public IWebElement MSPwd { get; set; }

        [FindsBy(How = How.Id, Using = "idSIButton9")]
        public IWebElement MSconfirm { get; set; }

        [FindsBy(How = How.LinkText, Using = "Programmes")]
        public IWebElement Programmes { get; set; }

        

    }
}
