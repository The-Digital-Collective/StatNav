using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Models;

namespace StatNav.UnitTests.ModelValidation
{
    [TestClass]
    public class MAPValidationTest
    {
        [TestMethod]
        public void CreateProgramme_ValidationOnNameGivesError()
        {
            //Arrange
            MarketingAssetPackage map = new MarketingAssetPackage { MAPName = "" };
            var context = new ValidationContext(map, null, null);
            var results = new List<ValidationResult>();
            //Act
            var isModelStateValid = Validator.TryValidateObject(map, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Package Name field is required.", results[0].ErrorMessage);
        }
    }
}
