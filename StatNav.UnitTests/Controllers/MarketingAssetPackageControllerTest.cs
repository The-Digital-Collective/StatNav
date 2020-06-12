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
        List<MarketingAssetPackage> _maps = null;
        DummyMAPRepository mapRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            status1 = new ExperimentStatus() { Id = 0, DisplayOrder = 1, StatusName = "Draft" };
            status2 = new ExperimentStatus() { Id = 1, DisplayOrder = 2, StatusName = "Scheduled" };
            status3 = new ExperimentStatus() { Id = 2, DisplayOrder = 3, StatusName = "Live" };
            //set up the dummy data for testing
            map1 = new MarketingAssetPackage() { MAPName = "Northern Lights", Id = 0 };
            map1.ExperimentStatus = status1;
            map2 = new MarketingAssetPackage() { MAPName = "Amber Spyglass", Id = 1 };
            map2.ExperimentStatus = status2;
            map3 = new MarketingAssetPackage() { MAPName = "Subtle Knife", Id = 2 };
            map3.ExperimentStatus = status3;
            _maps = new List<MarketingAssetPackage> { map1, map2, map3 };

            mapRepository = new DummyMAPRepository(_maps);
            _controller = new MarketingAssetPackageController(mapRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual("MarketingAssetPackage", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, map1);
            CollectionAssert.Contains(model, map2);
            CollectionAssert.Contains(model, map3);
        }

        

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
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
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
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
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStatus_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Status", string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByStatusDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("status_desc", string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<MarketingAssetPackage>)result.Model;
            // Assert
            Assert.AreEqual(model[0], map3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], map1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void IndexView_SearchByS_ReturnsExpectedPrograms()
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
        public void IndexView_SearchByX_ReturnsExpectedPrograms()
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
        public void Index_SearchByWord_ReturnsCorrectItems()
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
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
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
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
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
        public void MAPDetailView_Is_Passed_MAP_Data()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            MarketingAssetPackage ep = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(ep, map2);
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
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, mapRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), mapRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, mapRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), mapRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, mapRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), mapRepository.GetMethods().GetType());
        }

        [TestMethod]
        public void CreateValidMAP()
        {
            //Arrange
            MarketingAssetPackage newProg = new MarketingAssetPackage { MAPName = "MAPNew", Id = 7, ExperimentStatusId = 0, MAPImpactMetricModelId = 0, MAPTargetMetricModelId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newProg);
            //get list of all maprammes
            List<MarketingAssetPackage> maps = mapRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(maps, newProg);
            Assert.AreEqual("Edit", result.RouteValues["action"]);

        }


        [TestMethod]
        public void CreateMAP_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("test", "test");
            MarketingAssetPackage thisProg = new MarketingAssetPackage();
            //Act
            ViewResult result = _controller.Create(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditReturns_Is_Passed_MAP_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2);

            MarketingAssetPackage ep = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(ep, map3);
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
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, mapRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), mapRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).Count, mapRepository.GetStatuses().Count);
            Assert.AreEqual(((IList<ExperimentStatus>)result.ViewBag.ExperimentStatuses).GetType(), mapRepository.GetStatuses().GetType());
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).Count, mapRepository.GetMethods().Count);
            Assert.AreEqual(((IList<Method>)result.ViewBag.Methods).GetType(), mapRepository.GetMethods().GetType());

        }

        [TestMethod]
        public void EditMAPEditsModel()
        {
            //Arrange
            MarketingAssetPackage editedProg = new MarketingAssetPackage { MAPName = "MAPEdited", Id = 1, ExperimentStatusId = 0, MAPImpactMetricModelId = 0, MAPTargetMetricModelId = 0 };
         
            //Act
            var result = (RedirectToRouteResult)_controller.Edit(editedProg);
            //get list of all maprammes
            List<MarketingAssetPackage> maps = mapRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(maps, editedProg);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditMAP_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            MarketingAssetPackage thisProg = new MarketingAssetPackage();
            //Act
            ViewResult result = _controller.Edit(thisProg) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Is_Passed_MAP_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(1);

            MarketingAssetPackage ep = result.ViewData.Model as MarketingAssetPackage;

            // Assert           
            Assert.AreEqual(ep, map2);
        }


        [TestMethod]
        public void DeleteMAPDeletesModel()
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
