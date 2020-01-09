using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using Moq;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Models;
using StatNav.UnitTests.TestData;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class ProgrammeControllerTest
    {
        private ProgrammeController _controller;
        ExperimentProgramme prog1 = null;
        ExperimentProgramme prog2 = null;
        ExperimentProgramme prog3 = null;
        List<ExperimentProgramme> _programmes = null;
        DummyProgrammeRepository programmeRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up the dummy data for testing
            prog1 = new ExperimentProgramme() { ProgrammeName = "Programme0", Id = 0, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };
            prog2 = new ExperimentProgramme() { ProgrammeName = "Programme1", Id = 1, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };
            prog3 = new ExperimentProgramme() { ProgrammeName = "Programme2", Id = 2, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };
            _programmes = new List<ExperimentProgramme> { prog1, prog2, prog3 };

            programmeRepository = new DummyProgrammeRepository(_programmes);
            _controller = new ProgrammeController(programmeRepository);          
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual("Programme", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.Contains(model, prog3);
        }

        [TestMethod]
        public void ProgrammeDetailView_Is_Passed_Programme_Data()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            ExperimentProgramme ep = result.ViewData.Model as ExperimentProgramme;

            // Assert           
            Assert.AreEqual(ep, prog2);
        }

        [TestMethod]
        public void CreateReturns_CorrectActionAndView()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }



        [TestMethod]
        public void CreateValidProgramme()
        {
            //Arrange
            ExperimentProgramme newProg = new ExperimentProgramme { ProgrammeName = "ProgrammeNew", Id = 7, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newProg);
            //get list of all programmes
            List<ExperimentProgramme> progs = programmeRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, newProg);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }


        [TestMethod]
        public void CreateProgramme_ValidationErrorReturnsCorrectActionAndView()
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

        [TestMethod]
        public void EditReturns_Is_Passed_Programme_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2);

            ExperimentProgramme ep = result.ViewData.Model as ExperimentProgramme;

            // Assert           
            Assert.AreEqual(ep, prog3);
        }

        [TestMethod]
        public void EditReturnsCorrectAction()
        {
            //Arrange

            //Act
            ViewResult result = _controller.Edit(2) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditProgrammeEditsModel()
        {
            //Arrange
            ExperimentProgramme editedProg = new ExperimentProgramme { ProgrammeName = "ProgrammeEdited", Id = 1, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedProg);
            //get list of all programmes
            List<ExperimentProgramme> progs = programmeRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, editedProg);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditProgramme_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            ExperimentProgramme thisProg = new ExperimentProgramme();
            //Act
            ViewResult result = _controller.Edit(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Is_Passed_Programme_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(1);

            ExperimentProgramme ep = result.ViewData.Model as ExperimentProgramme;

            // Assert           
            Assert.AreEqual(ep, prog2);
        }


        [TestMethod]
        public void DeleteProgrammeDeletesModel()
        {
            //Arrange
           
            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(1);
            //get list of all programmes
            List<ExperimentProgramme> progs = programmeRepository.LoadList();

            // Assert
            CollectionAssert.DoesNotContain(progs, prog2);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
