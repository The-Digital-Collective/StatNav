using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using StatNav.WebApplication.Models;
using StatNav.UnitTests.TestData;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class ExperimentControllerTest
    {
        private ExperimentController _controller;
        Experiment experiment1 = null;
        Experiment experiment2 = null;
        Experiment experiment3 = null;
        List<Experiment> _experiments = null;
        DummyExperimentRepository experimentRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up the dummy data for testing
            experiment1 = new Experiment() { ExperimentName = "Victoria Sponge", Id = 1, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2019, 11, 1),EndDateTime= new System.DateTime(2019, 11, 30) };
            experiment2 = new Experiment() { ExperimentName = "Lemon Drizzle", Id = 2, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2019, 08, 1), EndDateTime = new System.DateTime(2020, 07, 31) };
            experiment3 = new Experiment() { ExperimentName = "Chocolate Fudge", Id = 3, MarketingAssetPackageId = 0, StartDateTime = new System.DateTime(2020, 01, 1), EndDateTime = new System.DateTime(2020, 03, 31) };
            _experiments = new List<Experiment> { experiment1, experiment2, experiment3};

            experimentRepository = new DummyExperimentRepository(_experiments);
            _controller = new ExperimentController(experimentRepository);
        }

        [TestMethod]
        public void Index_WhenCalled_ReturnsCorrectViewBagAndModels()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual("Experiment", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, experiment1);
            CollectionAssert.Contains(model, experiment2);
            CollectionAssert.Contains(model, experiment3);
        }

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStartDate_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("StartDate", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStartDateDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("startDate_desc", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByEndDate_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("EndDate", string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByEndDateDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("endDate_desc",string.Empty) as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            Assert.AreEqual(model[0], experiment2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], experiment1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void IndexView_SearchByO_ReturnsExpectedExperiments()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "o") as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            CollectionAssert.Contains(model, experiment1);
            CollectionAssert.Contains(model, experiment2);
            CollectionAssert.Contains(model, experiment3);
        }

        [TestMethod]
        public void IndexView_SearchByX_ReturnsExpectedExperiments()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, experiment1);
            CollectionAssert.DoesNotContain(model, experiment2);
            CollectionAssert.DoesNotContain(model, experiment3);
        }

        [TestMethod]
        public void Index_SearchByWord_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "lemon") as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, experiment1);
            CollectionAssert.Contains(model, experiment2);
            CollectionAssert.DoesNotContain(model, experiment3);
        }

        [TestMethod]
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "oN") as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            CollectionAssert.Contains(model, experiment1);
            CollectionAssert.Contains(model, experiment2);
            CollectionAssert.DoesNotContain(model, experiment3);
        }
        [TestMethod]
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("endDate_desc", "oN") as ViewResult;
            var model = (List<Experiment>)result.Model;
            // Assert
            CollectionAssert.Contains(model, experiment1);
            CollectionAssert.Contains(model, experiment2);
            CollectionAssert.DoesNotContain(model, experiment3);
            Assert.AreEqual(model[0], experiment2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], experiment1);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Detail_WhenCalled_IsPassedExperimentData()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            Experiment ex = result.ViewData.Model as Experiment;

            // Assert           
            Assert.AreEqual(ex, experiment1);
        }

        [TestMethod]
        public void Create_WhenCalled_ReturnsCorrectActionAndView()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;
            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Create_WhenCalled_ReturnsCorrectViewModels()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;

            // Assert           
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).Count, experimentRepository.GetMAPs().Count);
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).GetType(), experimentRepository.GetMAPs().GetType());
        }

        [TestMethod]
        public void Create_WhenCalledWithMAPId_ReturnsModelWithMAPId()
        {
            // Arrange
            int chosenMAPId = 2;
            // Act
            ViewResult result = _controller.Create(chosenMAPId) as ViewResult;
            Experiment ex = result.ViewData.Model as Experiment;
            // Assert
            Assert.AreEqual(ex.MarketingAssetPackageId, chosenMAPId);
        }


        [TestMethod]
        public void Create_WhenPosted_CreatesValidExperiment()
        {
            //Arrange
            Experiment newExperiment = new Experiment { ExperimentName = "ExperimentNew", Id = 7, MarketingAssetPackageId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newExperiment);
            //get list of all experiments
            List<Experiment> experiments = experimentRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(experiments, newExperiment);
            Assert.AreEqual("Edit", result.RouteValues["action"]);

        }


        [TestMethod]
        public void Create_WhenPostedWithValidationError_ReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("FakeError", "FakeError");
            Experiment thisExperiment = new Experiment();
            //Act
            ViewResult result = _controller.Create(thisExperiment) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Edit_WhenCalled_IsPassedExperimentData()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2,"");

            Experiment ex = result.ViewData.Model as Experiment;

            // Assert           
            Assert.AreEqual(ex, experiment2);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectAction()
        {
            //Arrange

            //Act
            ViewResult result = _controller.Edit(2, "") as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectViewBagsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1, "") as ViewResult;

            // Assert           
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).Count, experimentRepository.GetMAPs().Count);
            Assert.AreEqual(((IList<MarketingAssetPackage>)result.ViewBag.MarketingAssetPackages).GetType(), experimentRepository.GetMAPs().GetType());
        }


        [TestMethod]
        public void Edit_WhenPosted_EditsModel()
        {
            //Arrange
            Experiment editedExperiment = new Experiment { ExperimentName= "ExperimentEdited", Id = 1, MarketingAssetPackageId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedExperiment);
            //get list of all experiments
            List<Experiment> exps = experimentRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(exps, editedExperiment);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_WhenPostedWithValidationError_ReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            Experiment thisEx = new Experiment();
            //Act
            ViewResult result = _controller.Edit(thisEx) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_WhenCalled_IsPassedExperimentData()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(3);

            Experiment ex = result.ViewData.Model as Experiment;

            // Assert           
            Assert.AreEqual(ex, experiment3);
        }


        [TestMethod]
        public void Delete_WhenPosted_DeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(3);
            //get list of all experiments
            List<Experiment> experiments = experimentRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(experiments, experiment3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
