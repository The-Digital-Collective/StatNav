using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
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
            candidate1 = new ExperimentCandidate() { CandidateName = "Spider", Id = 1, ExperimentIterationId = 0 };
            candidate2 = new ExperimentCandidate() { CandidateName = "Armadillo", Id = 2, ExperimentIterationId = 0 };
            candidate3 = new ExperimentCandidate() { CandidateName = "Crab", Id = 3, ExperimentIterationId = 0 };
            _candidates = new List<ExperimentCandidate> { candidate1, candidate2, candidate3};

            candidateRepository = new DummyCandidateRepository(_candidates);
            _controller = new CandidateController(candidateRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual("Candidate", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, candidate1);
            CollectionAssert.Contains(model, candidate2);
            CollectionAssert.Contains(model, candidate3);
        }

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual(model[0], candidate2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], candidate1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual(model[0], candidate1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], candidate2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual(model[0], candidate1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], candidate3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            Assert.AreEqual(model[0], candidate3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], candidate1);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void IndexView_SearchByI_ReturnsExpectedCandidates()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "i") as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            CollectionAssert.Contains(model, candidate1);
            CollectionAssert.Contains(model, candidate2);
            CollectionAssert.DoesNotContain(model, candidate3);
        }

        [TestMethod]
        public void IndexView_SearchByX_ReturnsExpectedCandidates()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, candidate1);
            CollectionAssert.DoesNotContain(model, candidate2);
            CollectionAssert.DoesNotContain(model, candidate3);
        }

        [TestMethod]
        public void Index_SearchByWord_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "crab") as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, candidate1);
            CollectionAssert.DoesNotContain(model, candidate2);
            CollectionAssert.Contains(model, candidate3);
        }

        [TestMethod]
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "Pi") as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            CollectionAssert.Contains(model, candidate1);
            CollectionAssert.DoesNotContain(model, candidate2);
            CollectionAssert.DoesNotContain(model, candidate3);
        }
        [TestMethod]
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", "I") as ViewResult;
            var model = (List<ExperimentCandidate>)result.Model;
            // Assert
            CollectionAssert.Contains(model, candidate1);
            CollectionAssert.Contains(model, candidate2);
            CollectionAssert.DoesNotContain(model, candidate3);
            Assert.AreEqual(model[0], candidate2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], candidate1);//is the last one in the ordered the list the correct one?
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
        public void CreateView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, candidateRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), candidateRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentIteration>)result.ViewBag.ExperimentIterations).Count, candidateRepository.GetIterations().Count);
            Assert.AreEqual(((IList<ExperimentIteration>)result.ViewBag.ExperimentIterations).GetType(), candidateRepository.GetIterations().GetType());

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
            ExperimentCandidate newCandidate = new ExperimentCandidate { CandidateName = "CandidateNew", Id = 7, ExperimentIterationId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newCandidate);
            //get list of all candidates
            List<ExperimentCandidate> progs = candidateRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(progs, newCandidate);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
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
        public void EditView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, candidateRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), candidateRepository.GetMetricModels().GetType());           
            Assert.AreEqual(((IList<ExperimentIteration>)result.ViewBag.ExperimentIterations).Count, candidateRepository.GetIterations().Count);
            Assert.AreEqual(((IList<ExperimentIteration>)result.ViewBag.ExperimentIterations).GetType(), candidateRepository.GetIterations().GetType());

        }


        [TestMethod]
        public void EditCandidateEditsModel()
        {
            //Arrange
            ExperimentCandidate editedCandidate = new ExperimentCandidate { CandidateName = "CandidateEdited", Id = 1, ExperimentIterationId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedCandidate);
            //get list of all candidates
            List<ExperimentCandidate> progs = candidateRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(progs, editedCandidate);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
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
            List<ExperimentCandidate> candidates = candidateRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(candidates, candidate3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
