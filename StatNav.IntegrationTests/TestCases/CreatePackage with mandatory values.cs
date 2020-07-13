using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    public static class CreatePackageMandatory
    {      
        public static void CreatePackageMandatoryTest()
        {
            var rand = new Random();
            int val = rand.Next(999999);
            string Containarname = "Containar" + val;
            string Assetname = "Asset" + val;
            string Iterationname = "Iteration" + val;
            string Candidatename = "Candidate" + val;
            AppDriver.driver.FindElement(By.LinkText("Home")).Click();
            AppClass.CreatePackageContainer(Containarname, "Persistent","Reach", "");
            AppClass.CreateAssetPackage(Assetname, Containarname, "", "", "", "");
            AppClass.createiteration(Assetname, Iterationname);
            AppClass.createcandidate(Iterationname, Candidatename);
        }
    }
}
