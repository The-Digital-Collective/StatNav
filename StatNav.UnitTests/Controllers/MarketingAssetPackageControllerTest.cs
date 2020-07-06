using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using StatNav.WebApplication.Models;
using StatNav.UnitTests.TestData;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class MarketingAssetPackageControllerTest
    {
        private MarketingAssetPackageController _controller;
        ExperimentStatus status1 = null;
        ExperimentStatus status2 = null;
        ExperimentStatus status3 = null;
        MarketingAssetPackage map1 = null;
        MarketingAssetPackage map2 = null;
        MarketingAssetPackage map3 = null;
        ExperimentIteration childItem1 = null;
        ExperimentIteration childItem2 = null;
        ExperimentIteration childItem3 = null;
        List<MarketingAssetPackage> _maps = null;
        DummyMAPRepository mapRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            status1 = new ExperimentStatus() { Id = 0, DisplayOrder = 1, StatusName = "Draft" };
            status2 = new ExperimentStatus() { Id = 1, DisplayOrder = 2, StatusName = "Scheduled" };
            status3 = new ExperimentStatus() { Id = 2, DisplayOrder = 3, StatusName = "Live" };

            childItem1 = new ExperimentIteration() { Id = 1, MarketingAssetPackageId = 1, IterationName = "ChildItem1" };
            childItem2 = new ExperimentIteration() { Id = 2, MarketingAssetPackageId = 1, IterationName = "ChildItem2" };
            childItem3 = new ExperimentIteration() { Id = 3, MarketingAssetPackageId = 1, IterationName = "ChildItem3" };

            //set up the dummy data for testing
            map1 = new MarketingAssetPackage()
            {
                MAPName = "Northern Lights",
                Id = 0,
                Hypothesis = "Test Hypothesis",
                Problem = "Test Problem",
                ProblemValidation="Test Problem Validation",  
                Notes="Test Notes",
                ExperimentIterations = new List<ExperimentIteration>()
            { childItem1,childItem2,childItem3}
            };
            map2 = new MarketingAssetPackage() { MAPName = "Amber Spyglass", Id = 1 };
            map3 = new MarketingAssetPackage() { MAPName = "Subtle Knife", Id = 2 };
            _maps = new List<MarketingAssetPackage> { map1, map2, map3 };

            mapRepository = new DummyMAPRepository(_maps);
            _controller = new MarketingAssetPackageController(mapRepository);
        }

        [TestMethod]
        public void Index_WhenCalled_ViewBagCorrectTypeReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual("MarketingAssetPackage", result.ViewBag.SelectedType);
        }

        [TestMethod]
        public void Index_WhenCalled_CorrectModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert        
            CollectionAssert.Contains(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.Contains(model, map3);
        }


        [TestMethod]
        public void Index_WhenCalled_OrderByNameReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map3);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Index_WhenCalled_OrderByNameDescReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_WhenCalled_SearchBySReturnsExpectedMAPS()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "s") as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            CollectionAssert.Contains(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.Contains(model, map3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByXReturnsExpectedMAP()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, map1);
            CollectionAssert.DoesNotContain(model, map2);
            CollectionAssert.DoesNotContain(model, map3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByWordReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "amber") as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.DoesNotContain(model, map3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByCaseInsenstiveReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "Er") as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            CollectionAssert.Contains(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.DoesNotContain(model, map3);
        }
        [TestMethod]
        public void Index_WhenCalled_SearchByCaseInsenstiveAndOrderByReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", "Er") as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            CollectionAssert.Contains(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.DoesNotContain(model, map3);
            Assert.AreEqual(model[0], map1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], map2);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Detail_WhenCalled_IsPassedMAPData()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            MarketingAssetPackage map = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(map, map2);
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
        public void Create_WhenCalled_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, mapRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), mapRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, mapRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), mapRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, mapRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), mapRepository.GetMethods().GetType());
            Assert.AreEqual(((IList<PackageContainer>)result.ViewBag.PackageContainers).Count, mapRepository.GetPCs().Count);
            Assert.AreEqual(((IList<PackageContainer>)result.ViewBag.PackageContainers).GetType(), mapRepository.GetPCs().GetType());
        }

        [TestMethod]
        public void Create_WhenSubmittedWithValidModel_CreatesValidMAP()
        {
            //Arrange
            MarketingAssetPackage newMAP = new MarketingAssetPackage { MAPName = "MAPNew", Id = 7 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newMAP);
            //get list of all maprammes
            List<MarketingAssetPackage> maps = mapRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(maps, newMAP);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }


        [TestMethod]
        public void Create_WhenSubmittedWithInvalidModel_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("test", "test");
            MarketingAssetPackage thisMAP = new MarketingAssetPackage();
            //Act
            ViewResult result = _controller.Create(thisMAP) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectModel()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(0, "");

            MarketingAssetPackage map = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(map, map1);
            //check properties of model - story 2069
            Assert.AreEqual(map.ProblemValidation.GetType(), map1.ProblemValidation.GetType());
            Assert.AreEqual(map.Problem.GetType(), map1.Problem.GetType());
            Assert.AreEqual(map.Hypothesis.GetType(), map1.Hypothesis.GetType());
            Assert.AreEqual(map.MAPName.GetType(), map1.MAPName.GetType());
            Assert.AreEqual(map.Notes.GetType(), map1.Notes.GetType());
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
        public void Edit_WhenCalled_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1, "") as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, mapRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), mapRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, mapRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), mapRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, mapRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), mapRepository.GetMethods().GetType());

        }

        [TestMethod]
        public void Edit_WhenSubmitted_EditsModel()
        {
            //Arrange
            MarketingAssetPackage editedMAP = new MarketingAssetPackage { MAPName = "MAPEdited", Id = 1 };

            //Act
            var result = (RedirectToRouteResult)_controller.Edit(editedMAP);
            //get list of all MAPs
            List<MarketingAssetPackage> maps = mapRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(maps, editedMAP);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_WhenSubmittedInvalid_ErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            MarketingAssetPackage thisMAP = new MarketingAssetPackage();
            //Act
            ViewResult result = _controller.Edit(thisMAP) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectChildEntities()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(0, "");

            MarketingAssetPackage map = result.ViewData.Model as MarketingAssetPackage;
            List<ExperimentIteration> childItems = (List<ExperimentIteration>)map.ExperimentIterations;

            // Assert           
            Assert.AreEqual(map.ExperimentIterations.Count, 3);
            CollectionAssert.Contains(childItems, childItem1);
            CollectionAssert.Contains(childItems, childItem2);
            CollectionAssert.Contains(childItems, childItem3);
        }

        [TestMethod]
        public void Edit_WhenCalledFromSave_ReturnsCorrectConfirmation()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(1, "Saved");


            // Assert           
            Assert.AreEqual(result.ViewBag.Notification, "Save Successful");
        }

        [TestMethod]
        public void Delete_WhenCalled_IsPassedMAPData()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(1);

            MarketingAssetPackage map = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(map, map2);
        }


        [TestMethod]
        public void DeleteConfirm_WhenCalled_DeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(1);
            //get list of all maprammes
            List<MarketingAssetPackage> maps = mapRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(maps, map2);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
