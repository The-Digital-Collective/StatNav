using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using StatNav.IntegrationTests.TestCases;
using System;
using System.Configuration;
using TestAutomationFramework;

namespace StatNav.IntegrationTests
{
    //[TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(InternetExplorerDriver))]
   
    public class StatNavIntegrationTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {

        [OneTimeSetUp]
        public void Initialization()
        {
            Utils.DriverSetup();
            AppDriver.driver = new TWebDriver();
            AppClass.StatNavLogin();
        }

        [Test, Order(1)]
        public void ValidateHeaderTest()
        {
            ValidateHeaderMenu.ValidateHeaderMenuTest();
        }
        [Test, Order(2)]
        public void CreatePackageEntities()
        {
            CreateProgram.CreatePackage();
        }
        [Test, Order(3)]
        public void CreateMandatoryPackageEntities()
        {
            CreatePackageMandatory.CreatePackageMandatoryTest();
        }
        [Test, Order(4)]
        public void MandatoryPackageEntities()
        {
            ValidatePackageContainar.PackageContainarMandatoryTest();
            ValidateMarketingAsset.MarketingAssetMandatoryTest();
            ValidateExperiments.ExperimentsMandatoryTest();
            ValidateVariant.VariantMandatoryTest();
        }
        [Test, Order(5)]
        public void EditPackageEntities()
        {
            UpdatePackageContainar.PackageContainarUpdateTest();
            UpdateMarketingAsset.MarketingAssetUpdateTest();
            UpdateExperiments.ExperimentUpdateTest();
            UpdateVariant.VariantUpdateTest();
        }
        [Test, Order(5)]
        public void DeletePackagesEntities()
        {
            DeletePackages.DeletePackagesTest();
        }

      [OneTimeTearDown]
        public void Browser()
        {
            AppDriver.driver.Close();
        }
    }
}




