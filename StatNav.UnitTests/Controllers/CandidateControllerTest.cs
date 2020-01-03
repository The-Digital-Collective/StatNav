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
    public class CandidateControllerTest
    {
        private CandidateController _controller;
        ExperimentCandidate candidate1 = null;
        ExperimentCandidate candidate2 = null;
        ExperimentCandidate candidate3 = null;
        List<ExperimentCandidate> _candidates = null;
        DummyCandidateRepository candidateRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up the dummy data for testing
            candidate1 = new ExperimentCandidate() { Name = "Candidate1", Id = 1, ExperimentIterationId = 0 };
            candidate2 = new ExperimentCandidate() { Name = "Candidate2", Id = 2, ExperimentIterationId = 0 };
            candidate3 = new ExperimentCandidate() { Name = "Candidate3", Id = 3, ExperimentIterationId = 0 };
            _candidates = new List<ExperimentCandidate> { candidate1, candidate2, candidate3};

            candidateRepository = new DummyCandidateRepository(_candidates);
            _controller = new CandidateController(candidateRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index() as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual("Candidate", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, candidate1);
            CollectionAssert.Contains(model, candidate2);
            CollectionAssert.Contains(model, candidate3);
        }

        [TestMethod]
        public void CandidateDetailView_Is_Passed_Candidate_Data()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            ExperimentCandidate ec = result.ViewData.Model as ExperimentCandidate;

            // Assert           
            Assert.AreEqual(ec, candidate1);
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
        public void CreateWithIterationIdReturns_ModelWithIterationId()
        {
            // Arrange
            int chosenIterationId = 2;
            // Act
            ViewResult result = _controller.Create(chosenIterationId) as ViewResult;
            ExperimentCandidate ec = result.ViewData.Model as ExperimentCandidate;
            // Assert
            Assert.AreEqual(ec.ExperimentIterationId, chosenIterationId);
        }


        [TestMethod]
        public void CreateValidCandidate()
        {
            //Arrange
            ExperimentCandidate newCandidate = new ExperimentCandidate { Name = "CandidateNew", Id = 7, ExperimentIterationId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newCandidate);
            //get list of all candidates
            List<ExperimentCandidate> progs = candidateRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, newCandidate);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        [TestMethod]
        public void CreateCandidate_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("FakeError", "FakeError");
            ExperimentCandidate thisCandidate = new ExperimentCandidate();
            //Act
            ViewResult result = _controller.Create(thisCandidate) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditReturns_Is_Passed_Candidate_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2);

            ExperimentCandidate ec = result.ViewData.Model as ExperimentCandidate;

            // Assert           
            Assert.AreEqual(ec, candidate2);
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
        public void EditCandidateEditsModel()
        {
            //Arrange
            ExperimentCandidate editedCandidate = new ExperimentCandidate { Name = "CandidateEdited", Id = 1, ExperimentIterationId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedCandidate);
            //get list of all candidates
            List<ExperimentCandidate> progs = candidateRepository.LoadList();

            // Assert
            CollectionAssert.Contains(progs, editedCandidate);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditCandidate_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            ExperimentCandidate thisProg = new ExperimentCandidate();
            //Act
            ViewResult result = _controller.Edit(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Is_Passed_Candidate_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(3);

            ExperimentCandidate ec = result.ViewData.Model as ExperimentCandidate;

            // Assert           
            Assert.AreEqual(ec, candidate3);
        }


        [TestMethod]
        public void DeleteCandidateDeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(3);
            //get list of all candidates
            List<ExperimentCandidate> candidates = candidateRepository.LoadList();

            // Assert
            CollectionAssert.DoesNotContain(candidates, candidate3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
