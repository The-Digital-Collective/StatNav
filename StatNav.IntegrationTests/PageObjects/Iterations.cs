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

        [FindsBy(How = How.Id, Using = "IterationName")]
        public IWebElement IterationName { get; set; }

        [FindsBy(How = How.Id, Using = "RequiredDurationForSignificance")]
        public IWebElement RequiredDurationForSignificance { get; set; }

        [FindsBy(How = How.Id, Using = "IterationNumber")]
        public IWebElement IterationNumber { get; set; }


        [FindsBy(How = How.Name, Using = "StartDateTime")]
        public IWebElement StartDateTime { get; set; }


        [FindsBy(How = How.Name, Using = "EndDateTime")]
        public IWebElement EndDateTime { get; set; }


        [FindsBy(How = How.Id, Using = "SuccessOutcome")]
        public IWebElement SuccessOutcome { get; set; }


        [FindsBy(How = How.Id, Using = "FailureOutcome")]
        public IWebElement FailureOutcome { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement SaveCandidate { get; set; }


        [FindsBy(How = How.LinkText, Using = "Create Candidate for this Iteration")]
        public IWebElement Create_Candidate { get; set; }


    }
}
