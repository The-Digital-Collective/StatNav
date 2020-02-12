using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatNav.IntegrationTests.PageObjects
{
    class Iterations
    {
        public Iterations()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[2]/a")]
        public IWebElement Create_Iteration_Link { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ExperimentProgrammeId']")]
        public IWebElement ddlExperimentProgrammeId { get; set; }
    }
}
