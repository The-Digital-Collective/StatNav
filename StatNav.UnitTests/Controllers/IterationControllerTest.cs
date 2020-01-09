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
    public class IterationControllerTest
    {
        private IterationController _controller;
        ExperimentIteration iteration1 = null;
        ExperimentIteration iteration2 = null;
        ExperimentIteration iteration3 = null;
        List<ExperimentIteration> _iterations = null;
        DummyIterationRepository iterationRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up the dummy data for testing
            iteration1 = new ExperimentIteration() { IterationName= "Iteration1", Id = 1, ExperimentProgrammeId = 0 };
            iteration2 = new ExperimentIteration() { IterationName = "Iteration2", Id = 2, ExperimentProgrammeId = 0 };
            iteration3 = new ExperimentIteration() { IterationName = "Iteration3", Id = 3, ExperimentProgrammeId = 0 };
            _iterations = new List<ExperimentIteration> { iteration1, iteration2, iteration3};

            iterationRepository = new DummyIterationRepository(_iterations);
            _controller = new IterationController(iterationRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual("Iteration", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.Contains(model, iteration3);
        }

        [TestMethod]
        public void IterationDetailView_Is_Passed_Iteration_Data()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            ExperimentIteration ei = result.ViewData.Model as ExperimentIteration;

            // Assert           
            Assert.AreEqual(ei, iteration1);
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
        public void CreateWithProgrammeIdReturns_ModelWithProgrammeId()
        {
            // Arrange
            int chosenProgrammeId = 2;
            // Act
            ViewResult result = _controller.Create(chosenProgrammeId) as ViewResult;
            ExperimentIteration ei = result.ViewData.Model as ExperimentIteration;
            // Assert
            Assert.AreEqual(ei.ExperimentProgrammeId, chosenProgrammeId);
        }


        [TestMethod]
        public void CreateValidIteration()
        {
            //Arrange
            ExperimentIteration newIteration = new ExperimentIteration { IterationName = "IterationNew", Id = 7, ExperimentProgrammeId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newIteration);
            //get list of all iterations
            List<ExperimentIteration> progs = iterationRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, newIteration);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }


        [TestMethod]
        public void CreateIteration_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("FakeError", "FakeError");
            ExperimentIteration thisIteration = new ExperimentIteration();
            //Act
            ViewResult result = _controller.Create(thisIteration) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditReturns_Is_Passed_Iteration_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2);

            ExperimentIteration ei = result.ViewData.Model as ExperimentIteration;

            // Assert           
            Assert.AreEqual(ei, iteration2);
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
        public void EditIterationEditsModel()
        {
            //Arrange
            ExperimentIteration editedIteration = new ExperimentIteration { IterationName= "IterationEdited", Id = 1, ExperimentProgrammeId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedIteration);
            //get list of all iterations
            List<ExperimentIteration> progs = iterationRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, editedIteration);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditIteration_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            ExperimentIteration thisProg = new ExperimentIteration();
            //Act
            ViewResult result = _controller.Edit(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Is_Passed_Iteration_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(3);

            ExperimentIteration ei = result.ViewData.Model as ExperimentIteration;

            // Assert           
            Assert.AreEqual(ei, iteration3);
        }


        [TestMethod]
        public void DeleteIterationDeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(3);
            //get list of all iterations
            List<ExperimentIteration> iterations = iterationRepository.LoadList();

            // Assert
            CollectionAssert.DoesNotContain(iterations, iteration3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
