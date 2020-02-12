using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using StatNav.IntegrationTests.PageObjects;

namespace StatNav.IntegrationTests
{
     enum ProperType
    {
        id,
        name,
        linkText,
        xpath
    }
    class AppDriver
    {
        public static IWebDriver driver { get; set; }
        public static ExtentHtmlReporter htmlReporter { get; set; }
        public static ExtentReports extent { get; set; }
        public static ExtentTest test { get; set; }

        public static WebDriverWait wait { get; set; }
        public static StatNav spage { get; set; }
        public static Programmes ppage { get; set; }
        public static Iterations ipage { get; set; }

        public static Screenshot file;

    }
      
}
