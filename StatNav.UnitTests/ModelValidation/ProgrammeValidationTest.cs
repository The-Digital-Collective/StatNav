using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Models;

namespace StatNav.UnitTests.ModelValidation
{
    [TestClass]
    public class ProgrammeValidationTest
    {
        [TestMethod]
        public void CreateProgramme_ValidationOnNameGivesError()
        {
            //Arrange
            ExperimentProgramme ep = new ExperimentProgramme { ProgrammeName = "" };
            var context = new ValidationContext(ep, null, null);
            var results = new List<ValidationResult>();
            //Act
            var isModelStateValid = Validator.TryValidateObject(ep, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Name field is required.", results[0].ErrorMessage);
        }
    }
}
