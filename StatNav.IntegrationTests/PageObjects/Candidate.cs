using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatNav.IntegrationTests.PageObjects
{
    class Candidate
    {
        public Candidate()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "CandidateName")]
        public IWebElement CandidateName { get; set; }

        [FindsBy(How = How.Id, Using = "Control")]
        public IWebElement Control { get; set; }

        [FindsBy(How = How.Id, Using = "CandidateTargetMetricModelId")]
        public IWebElement CandidateTargetMetricModelId { get; set; }

        [FindsBy(How = How.Id, Using = "TargetMet")]
        public IWebElement TargetMet { get; set; }

        [FindsBy(How = How.Id, Using = "CandidateImpactMetricModelId")]
        public IWebElement CandidateImpactMetricModelId { get; set; }

        [FindsBy(How = How.Id, Using = "ImpactMet")]
        public IWebElement ImpactMet { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement savecandidate { get; set; }

    }
}
