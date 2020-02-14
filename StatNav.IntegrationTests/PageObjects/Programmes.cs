using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace StatNav.IntegrationTests.PageObjects
{
    class Programmes
    {
          public Programmes()
        {
            PageFactory.InitElements(AppDriver.driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        public IWebElement btnCreateNew { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProgrammeName']")]
        public IWebElement txtProgrammeName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Problem']")]
        public IWebElement txtProblem { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProblemValidation']")]
        public IWebElement txtProblemValidation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Hypothesis']")]
        public IWebElement txtHypothesis { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='MethodId']")]
        public IWebElement ddlMethod { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProgrammeTargetMetricModelId']")]
        public IWebElement ddlTargetMetric { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='TargetValue']")]
        public IWebElement txtTargetValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProgrammeImpactMetricModelId']")]
        public IWebElement ddlImpactMetric { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ImpactValue']")]
        public IWebElement txtImpactValue { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='ExperimentStatusId']")]
        public IWebElement ddlStatus { get; set; } 

        [FindsBy(How = How.XPath, Using = "//*[@id='Notes']")]
        public IWebElement txtNotes { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[1]/form/div/div[1]/div/input")]
        public IWebElement btnSave { get; set; }

        [FindsBy(How = How.LinkText, Using = "Back to List")]
        public IWebElement Back_to_List { get; set; }
       
        [FindsBy(How = How.LinkText, Using = "Delete")]
        public IWebElement btnDelete { get; set; }
    }
}
