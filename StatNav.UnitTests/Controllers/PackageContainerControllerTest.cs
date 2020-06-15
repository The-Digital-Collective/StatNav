using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using StatNav.WebApplication.Models;
using StatNav.UnitTests.TestData;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class PackageContainerControllerTest
    {
        private PackageContainerController _controller;

        PackageContainer pc1 = null;
        PackageContainer pc2 = null;
        PackageContainer pc3 = null;
        MetricModelStage mms1 = null;
        MetricModelStage mms2 = null;
        MetricModelStage mms3 = null;
        MarketingAssetPackage childItem1 = null;
        MarketingAssetPackage childItem2 = null;
        MarketingAssetPackage childItem3 = null;
        List<PackageContainer> _pcs = null;
        DummyPCRepository pcRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up foreign key relationship entities
            mms1 = new MetricModelStage() { Title = "Reach", Id = 1 };
            mms2 = new MetricModelStage() { Title = "Act", Id = 2 };
            mms3 = new MetricModelStage() { Title = "Convert", Id = 3 };

            childItem1 = new MarketingAssetPackage() { Id = 1, PackageContainerId = 1, MAPName = "ChildItem1" };
            childItem2 = new MarketingAssetPackage() { Id = 2, PackageContainerId = 1, MAPName = "ChildItem2" };
            childItem3 = new MarketingAssetPackage() { Id = 3, PackageContainerId = 1, MAPName = "ChildItem3" };


            //set up the dummy data for testing
            pc1 = new PackageContainer()
            {
                PackageContainerName = "Thunder and Lightening",
                Id = 1,
                Type = "Scary",
                MetricModelStageId = 1,
                MetricModelStage = mms1,
                MarketingAssetPackages = new List<MarketingAssetPackage>()
            {childItem1,childItem2 ,childItem3 }
            };
            pc2 = new PackageContainer() { PackageContainerName = "Rain and Wind", Id = 2, Type = "Bad Hair", MetricModelStageId = 2, MetricModelStage = mms2 };
            pc3 = new PackageContainer() { PackageContainerName = "Sunshine and Showers", Id = 3, Type = "April Flowers", MetricModelStageId = 3, MetricModelStage = mms3 };
            _pcs = new List<PackageContainer> { pc1, pc2, pc3 };

            pcRepository = new DummyPCRepository(_pcs);
            _controller = new PackageContainerController(pcRepository);
        }

        [TestMethod]
        public void Index_WhenCalled_ViewBagCorrectTypeReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;

            // Assert
            Assert.AreEqual("PackageContainer", result.ViewBag.SelectedType);
        }

        [TestMethod]
        public void Index_WhenCalled_CorrectModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert        
            CollectionAssert.Contains(model, pc1);
            CollectionAssert.Contains(model, pc2);
            CollectionAssert.Contains(model, pc3);
        }

        [TestMethod]
        public void Index_WhenCalled_OrderByNameReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            Assert.AreEqual(model[0], pc2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], pc1);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Index_WhenCalled_OrderByNameDescReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            Assert.AreEqual(model[0], pc1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], pc2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_WhenCalled_OrderByStageReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("stage", string.Empty) as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            Assert.AreEqual(model[0], pc2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], pc1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_WhenCalled_OrderByStageDescReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("stage_desc", string.Empty) as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            Assert.AreEqual(model[0], pc1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], pc2);//is the last one in the ordered the list the correct one?
        }      

        [TestMethod]
        public void Index_WhenCalled_SearchByIReturnsExpectedPCS()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "i") as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            CollectionAssert.Contains(model, pc1);
            CollectionAssert.Contains(model, pc2);
            CollectionAssert.Contains(model, pc3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByXReturnsExpectedPC()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, pc1);
            CollectionAssert.DoesNotContain(model, pc2);
            CollectionAssert.DoesNotContain(model, pc3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByWordReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "wind") as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, pc1);
            CollectionAssert.Contains(model, pc2);
            CollectionAssert.DoesNotContain(model, pc3);
        }

        [TestMethod]
        public void Index_WhenCalled_SearchByCaseInsenstiveReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "Er") as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            CollectionAssert.Contains(model, pc1);
            CollectionAssert.Contains(model, pc3);
            CollectionAssert.DoesNotContain(model, pc2);
        }
        [TestMethod]
        public void Index_WhenCalled_SearchByCaseInsenstiveAndOrderByReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", "Er") as ViewResult;
            var model = (List<PackageContainer>)result.Model;
            // Assert
            CollectionAssert.Contains(model, pc1);
            CollectionAssert.Contains(model, pc3);
            CollectionAssert.DoesNotContain(model, pc2);
            Assert.AreEqual(model[0], pc1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], pc3);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void Detail_WhenCalled_IsPassedPCData()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(2);

            PackageContainer pc = result.ViewData.Model as PackageContainer;

            // Assert           
            Assert.AreEqual(pc, pc2);
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
            Assert.AreEqual(((IList<MetricModelStage>)result.ViewBag.Stages).Count, pcRepository.GetStages().Count);
            Assert.AreEqual(((IList<MetricModelStage>)result.ViewBag.Stages).GetType(), pcRepository.GetStages().GetType());
        }

        [TestMethod]
        public void Create_WhenSubmittedWithValidModel_CreatesValidPC()
        {
            //Arrange
            PackageContainer newPC = new PackageContainer { PackageContainerName = "pcNew", Id = 7, MetricModelStageId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newPC);
            //get list of all PCs
            List<PackageContainer> pcs = pcRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(pcs, newPC);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }


        [TestMethod]
        public void Create_WhenSubmittedWithInvalidModel_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("test", "test");
            PackageContainer thispc = new PackageContainer();
            //Act
            ViewResult result = _controller.Create(thispc) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectModel()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(3, "");

            PackageContainer pc = result.ViewData.Model as PackageContainer;

            // Assert           
            Assert.AreEqual(pc, pc3);
        }

        [TestMethod]
        public void Edit_WhenCalled_ReturnsCorrectChildEntities()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(1, "");

            PackageContainer pc =  result.ViewData.Model as PackageContainer;
            List<MarketingAssetPackage> childItems = (List < MarketingAssetPackage > )pc.MarketingAssetPackages;

            // Assert           
            Assert.AreEqual(pc.MarketingAssetPackages.Count, 3);
            CollectionAssert.Contains(childItems, childItem1);
            CollectionAssert.Contains(childItems, childItem2);
            CollectionAssert.Contains(childItems, childItem3);
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
            // Assert
            Assert.AreEqual(((IList<MetricModelStage>)result.ViewBag.Stages).Count, pcRepository.GetStages().Count);
            Assert.AreEqual(((IList<MetricModelStage>)result.ViewBag.Stages).GetType(), pcRepository.GetStages().GetType());

        }

        [TestMethod]
        public void Edit_WhenSubmitted_EditsModel()
        {
            //Arrange
            PackageContainer editedpc = new PackageContainer { PackageContainerName = "pcEdited", Id = 1, MetricModelStageId = 0 };

            //Act
            var result = (RedirectToRouteResult)_controller.Edit(editedpc);
            //get list of all pcs
            List<PackageContainer> pcs = pcRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.Contains(pcs, editedpc);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_WhenSubmittedInvalid_ErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            PackageContainer thispc = new PackageContainer();
            //Act
            ViewResult result = _controller.Edit(thispc) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_WhenCalled_IsPassedPCData()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(1);

            PackageContainer pc = result.ViewData.Model as PackageContainer;

            // Assert           
            Assert.AreEqual(pc, pc1);
        }


        [TestMethod]
        public void DeleteConfirm_WhenCalled_DeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(1);
            //get list of all pcrammes
            List<PackageContainer> pcs = pcRepository.LoadList(string.Empty, string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(pcs, pc1);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
