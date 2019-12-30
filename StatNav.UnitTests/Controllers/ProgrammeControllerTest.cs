using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using Moq;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Models;
using StatNav.WebApplication.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class ProgrammeControllerTest
    {
        private ProgrammeController _controller;
        Mock<IProgrammeRepository> _mockRepository;
        List<ExperimentProgramme> _programmes;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IProgrammeRepository>();
            _programmes = new List<ExperimentProgramme>();
            _controller = new ProgrammeController(_mockRepository.Object);

        }

        [TestMethod]
        public void ProgrammeDetailView_Is_Passed_Programme_Data()
        {
            // Arrange
            _programmes.Add(new ExperimentProgramme() { Name = "Programme0", Id = 0, ExperimentStatusId = 0, ImpactMetricModelId = 0, TargetMetricModelId = 0 });
            _programmes.Add(new ExperimentProgramme() { Name = "Programme1", Id = 1, ExperimentStatusId = 0, ImpactMetricModelId = 0, TargetMetricModelId = 0 });
            _programmes.Add(new ExperimentProgramme() { Name = "Programme2", Id = 2, ExperimentStatusId = 0, ImpactMetricModelId = 0, TargetMetricModelId = 0 });
            _mockRepository.Setup(x => x.Load(It.IsAny<int>())).Returns((int i) => _programmes[i]);

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            ExperimentProgramme ep = result.ViewData.Model as ExperimentProgramme;

            // Assert
            Assert.IsNotNull(ep, "The model used should be an Experient Programme");
            Assert.AreEqual("Programme1", ep.Name);
        }

        [TestMethod]
        public void IndexViewBag()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;
            // Assert
            Assert.AreEqual("Programme", result.ViewBag.SelectedType);
        }

        public void CreateReturnsCorrectAction()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
        }



        [TestMethod]
        public void CreateValidProgramme()
        {
            //Arrange
            ExperimentProgramme ep = new ExperimentProgramme { Name = "Programme0", Id = 0, ExperimentStatusId = 0, ImpactMetricModelId = 0, TargetMetricModelId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(ep);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void CreateProgramme_ValidationOnNameGivesError()
        {
            //Arrange
            ExperimentProgramme ep = new ExperimentProgramme { Name = null};
            var context = new ValidationContext(ep,null,null);
            var results = new List<ValidationResult>();
            //Act
            var isModelStateValid = Validator.TryValidateObject(ep, context, results, true);

            // Assert
            Assert.IsFalse(isModelStateValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Name field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void CreateProgramme_ValidationErrorReturnsView()
        {
            //Arrange
            _controller.ModelState.AddModelError("test", "test");
            ExperimentProgramme thisProg = new ExperimentProgramme();
            //Act
            ViewResult result = _controller.Create(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }


    }
}
