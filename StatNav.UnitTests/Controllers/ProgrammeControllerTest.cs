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
        ExperimentStatus status1 = null;
        ExperimentStatus status2 = null;
        ExperimentStatus status3 = null;
        ExperimentProgramme prog1 = null;
        ExperimentProgramme prog2 = null;
        ExperimentProgramme prog3 = null;
        List<ExperimentProgramme> _programmes = null;
        DummyProgrammeRepository programmeRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            status1 = new ExperimentStatus() { Id = 0, DisplayOrder = 1, StatusName = "Draft" };
            status2 = new ExperimentStatus() { Id = 1, DisplayOrder = 2, StatusName = "Scheduled" };
            status3 = new ExperimentStatus() { Id = 2, DisplayOrder = 3, StatusName = "Live" };
            //set up the dummy data for testing
            prog1 = new ExperimentProgramme() { ProgrammeName = "Northern Lights", Id = 0, ExperimentStatusId = 0};
            prog2 = new ExperimentProgramme() { ProgrammeName = "Amber Spyglass", Id = 1, ExperimentStatusId = 1};
            prog3 = new ExperimentProgramme() { ProgrammeName = "Subtle Knife", Id = 2, ExperimentStatusId = 2};
            _programmes = new List<ExperimentProgramme> { prog1, prog2, prog3 };

            programmeRepository = new DummyProgrammeRepository(_programmes);
            _controller = new ProgrammeController(programmeRepository);          
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual("Programme", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.Contains(model, prog3);
        }

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog3);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog3);//is the last one in the ordered the list the correct one?
        }

        public void Index_OrderByStatus_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStatusDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog1);//is the last one in the ordered the list the correct one?
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
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty);

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
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty);

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
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(progs, prog2);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
