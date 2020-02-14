using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace StatNav.IntegrationTests
{
    public static class SeleniumGetMethods
    {
        public static string gettext(this IWebElement element)
        {
            return element.GetAttribute("value");
        }
        public static string gettextfromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;    
        }
    }
}
