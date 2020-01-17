using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
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
            prog1 = new ExperimentProgramme() { ProgrammeName = "Northern Lights", Id = 0 };
            prog1.ExperimentStatus = status1;
            prog2 = new ExperimentProgramme() { ProgrammeName = "Amber Spyglass", Id = 1 };
            prog2.ExperimentStatus = status2;
            prog3 = new ExperimentProgramme() { ProgrammeName = "Subtle Knife", Id = 2 };
            prog3.ExperimentStatus = status3;
            _programmes = new List<ExperimentProgramme> { prog1, prog2, prog3 };

            programmeRepository = new DummyProgrammeRepository(_programmes);
            _controller = new ProgrammeController(programmeRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
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
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
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
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
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
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStatus_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Status", string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStatusDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("status_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            Assert.AreEqual(model[0], prog3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], prog1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void IndexView_SearchByS_ReturnsExpectedPrograms()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "s") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            CollectionAssert.Contains(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.Contains(model, prog3);
        }

        [TestMethod]
        public void IndexView_SearchByX_ReturnsExpectedPrograms()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, prog1);
            CollectionAssert.DoesNotContain(model, prog2);
            CollectionAssert.DoesNotContain(model, prog3);
        }

        [TestMethod]
        public void Index_SearchByWord_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "amber") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.DoesNotContain(model, prog3);
        }

        [TestMethod]
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "Er") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            CollectionAssert.Contains(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.DoesNotContain(model, prog3);
        }
        [TestMethod]
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", "Er") as ViewResult;
            var model = (List<ExperimentProgramme>)result.Model;
            // Assert
            CollectionAssert.Contains(model, prog1);
            CollectionAssert.Contains(model, prog2);
            CollectionAssert.DoesNotContain(model, prog3);
            Assert.AreEqual(model[0], prog1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], prog2);//is the last one in the ordered the list the correct one?
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
        public void CreateView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, programmeRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), programmeRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, programmeRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), programmeRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, programmeRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), programmeRepository.GetMethods().GetType());
        }

        [TestMethod]
        public void CreateValidProgramme()
        {
            //Arrange
            ExperimentProgramme newProg = new ExperimentProgramme { ProgrammeName = "ProgrammeNew", Id = 7, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newProg);
            //get list of all programmes
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty, string.Empty);

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
        public void EditView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, programmeRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), programmeRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, programmeRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), programmeRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, programmeRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), programmeRepository.GetMethods().GetType());

        }

        [TestMethod]
        public void EditProgrammeEditsModel()
        {
            //Arrange
            ExperimentProgramme editedProg = new ExperimentProgramme { ProgrammeName = "ProgrammeEdited", Id = 1, ExperimentStatusId = 0, ProgrammeImpactMetricModelId = 0, ProgrammeTargetMetricModelId = 0 };
         
            //Act
            var result = (RedirectToRouteResult)_controller.Edit(editedProg);
            //get list of all programmes
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(progs, editedProg);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
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
            List<ExperimentProgramme> progs = programmeRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(progs, prog2);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
