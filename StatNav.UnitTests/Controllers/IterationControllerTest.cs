using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
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
            iteration1 = new ExperimentIteration() { IterationName = "Victoria Sponge", Id = 1, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2019, 11, 1),EndDateTime= new System.DateTime(2019, 11, 30) };
            iteration2 = new ExperimentIteration() { IterationName = "Lemon Drizzle", Id = 2, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2019, 08, 1), EndDateTime = new System.DateTime(2020, 07, 31) };
            iteration3 = new ExperimentIteration() { IterationName = "Chocolate Fudge", Id = 3, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2020, 01, 1), EndDateTime = new System.DateTime(2020, 03, 31) };
            _iterations = new List<ExperimentIteration> { iteration1, iteration2, iteration3};

            iterationRepository = new DummyIterationRepository(_iterations);
            _controller = new IterationController(iterationRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual("Iteration", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.Contains(model, iteration3);
        }

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStartDate_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("StartDate", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStartDateDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("startDate_desc", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByEndDate_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("EndDate", string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByEndDateDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("endDate_desc",string.Empty) as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            Assert.AreEqual(model[0], iteration2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], iteration1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void IndexView_SearchByO_ReturnsExpectedIterations()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "o") as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            CollectionAssert.Contains(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.Contains(model, iteration3);
        }

        [TestMethod]
        public void IndexView_SearchByX_ReturnsExpectedIterations()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, iteration1);
            CollectionAssert.DoesNotContain(model, iteration2);
            CollectionAssert.DoesNotContain(model, iteration3);
        }

        [TestMethod]
        public void Index_SearchByWord_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "lemon") as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.DoesNotContain(model, iteration3);
        }

        [TestMethod]
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "oN") as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            CollectionAssert.Contains(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.DoesNotContain(model, iteration3);
        }
        [TestMethod]
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("endDate_desc", "oN") as ViewResult;
            var model = (List<ExperimentIteration>)result.Model;
            // Assert
            CollectionAssert.Contains(model, iteration1);
            CollectionAssert.Contains(model, iteration2);
            CollectionAssert.DoesNotContain(model, iteration3);
            Assert.AreEqual(model[0], iteration2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], iteration1);//is the last one in the ordered the list the correct one?
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
        public void CreateView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;

            // Assert           
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).Count, iterationRepository.GetMAPs().Count);
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).GetType(), iterationRepository.GetMAPs().GetType());
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
            Assert.AreEqual(ei.MarketingAssetPackageId, chosenProgrammeId);
        }


        [TestMethod]
        public void CreateValidIteration()
        {
            //Arrange
            ExperimentIteration newIteration = new ExperimentIteration { IterationName = "IterationNew", Id = 7, MarketingAssetPackageId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newIteration);
            //get list of all iterations
            List<ExperimentIteration> progs = iterationRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(progs, newIteration);
            Assert.AreEqual("Edit", result.RouteValues["action"]);

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
        public void EditView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1) as ViewResult;

            // Assert           
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).Count, iterationRepository.GetMAPs().Count);
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).GetType(), iterationRepository.GetMAPs().GetType());
        }


        [TestMethod]
        public void EditIterationEditsModel()
        {
            //Arrange
            ExperimentIteration editedIteration = new ExperimentIteration { IterationName= "IterationEdited", Id = 1, MarketingAssetPackageId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedIteration);
            //get list of all iterations
            List<ExperimentIteration> progs = iterationRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(progs, editedIteration);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
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
            List<ExperimentIteration> iterations = iterationRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(iterations, iteration3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
