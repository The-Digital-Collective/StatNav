using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class CreateProgram
    {      
        public static void CreatePackage()
        {
            var rand = new Random();
            int val = rand.Next(999999);
            string Containarname = "Containar" + val;
            string Assetname = "Asset" + val;
            string Iterationname = "Iteration" + val;
            string Candidatename = "Candidate" + val;
            AppDriver.driver.FindElement(By.LinkText("Home")).Click();
            AppClass.CreatePackageContainer(Containarname, "Persistent","Reach", "notes");
            AppClass.CreateAssetPackage(Assetname, Containarname, "Hypothesis", "Problem", "ProblemValidation", "notes");
            AppClass.createiteration(Assetname, Iterationname);
            AppClass.createcandidate(Iterationname, Candidatename);
            AppClass.CreatePackageContainer("DynamicCont"+val, "Dynamic", "Act", "notes");
        }
    }
}
