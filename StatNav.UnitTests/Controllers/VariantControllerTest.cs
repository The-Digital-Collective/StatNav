using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using StatNav.WebApplication.Models;
using StatNav.UnitTests.TestData;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class VariantControllerTest
    {
        private VariantController _controller;
        Variant variant1 = null;
        Variant variant2 = null;
        Variant variant3 = null;
        List<Variant> _variants = null;
        DummyVariantRepository variantRepository = null;

        [TestInitialize]
        public void TestInitialize()
        {
            //set up the dummy data for testing
            variant1 = new Variant() { VariantName = "Spider", Id = 1, ExperimentId = 0 };
            variant2 = new Variant() { VariantName = "Armadillo", Id = 2, ExperimentId = 0 };
            variant3 = new Variant() { VariantName = "Crab", Id = 3, ExperimentId = 0 };
            _variants = new List<Variant> { variant1, variant2, variant3};

            variantRepository = new DummyVariantRepository(_variants);
            _controller = new VariantController(variantRepository);
        }

        [TestMethod]
        public void IndexViewBag_CorrectTypeReturned_And_ModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            Assert.AreEqual("Variant", result.ViewBag.SelectedType);
            CollectionAssert.Contains(model, variant1);
            CollectionAssert.Contains(model, variant2);
            CollectionAssert.Contains(model, variant3);
        }

        [TestMethod]
        public void Index_OrderByName_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, string.Empty) as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            Assert.AreEqual(model[0], variant2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], variant1);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByNameDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("name_desc", string.Empty) as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            Assert.AreEqual(model[0], variant1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], variant2);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderById_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("Id", string.Empty) as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            Assert.AreEqual(model[0], variant1);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], variant3);//is the last one in the ordered the list the correct one?
        }

        [TestMethod]
        public void Index_OrderByIdDesc_ReturnsCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", string.Empty) as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            Assert.AreEqual(model[0], variant3);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[2], variant1);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void IndexView_SearchByI_ReturnsExpectedVariants()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "i") as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            CollectionAssert.Contains(model, variant1);
            CollectionAssert.Contains(model, variant2);
            CollectionAssert.DoesNotContain(model, variant3);
        }

        [TestMethod]
        public void IndexView_SearchByX_ReturnsExpectedVariants()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index(string.Empty, "x") as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, variant1);
            CollectionAssert.DoesNotContain(model, variant2);
            CollectionAssert.DoesNotContain(model, variant3);
        }

        [TestMethod]
        public void Index_SearchByWord_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "crab") as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            CollectionAssert.DoesNotContain(model, variant1);
            CollectionAssert.DoesNotContain(model, variant2);
            CollectionAssert.Contains(model, variant3);
        }

        [TestMethod]
        public void Index_SearchByCaseInsenstive_ReturnsCorrectItems()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("", "Pi") as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            CollectionAssert.Contains(model, variant1);
            CollectionAssert.DoesNotContain(model, variant2);
            CollectionAssert.DoesNotContain(model, variant3);
        }
        [TestMethod]
        public void Index_SearchByCaseInsenstive_AndOrderBy_ReturnsCorrectItemsInCorrectOrder()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Index("id_desc", "I") as ViewResult;
            var model = (List<Variant>)result.Model;
            // Assert
            CollectionAssert.Contains(model, variant1);
            CollectionAssert.Contains(model, variant2);
            CollectionAssert.DoesNotContain(model, variant3);
            Assert.AreEqual(model[0], variant2);//is the first one in the ordered the list the correct one?
            Assert.AreEqual(model[1], variant1);//is the last one in the ordered the list the correct one?
        }
        [TestMethod]
        public void VariantDetailView_Is_Passed_Variant_Data()
        {
            // Arrange

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            Variant variant = result.ViewData.Model as Variant;

            // Assert           
            Assert.AreEqual(variant, variant1);
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
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, variantRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), variantRepository.GetMetricModels().GetType());
            Assert.AreEqual(((IList<Experiment>)result.ViewBag.Experiments).Count, variantRepository.GetExperiments().Count);
            Assert.AreEqual(((IList<Experiment>)result.ViewBag.Experiments).GetType(), variantRepository.GetExperiments().GetType());

        }

        [TestMethod]
        public void CreateWithExperimentIdReturns_ModelWithExperimentId()
        {
            // Arrange
            int chosenExperimentId = 2;
            // Act
            ViewResult result = _controller.Create(chosenExperimentId) as ViewResult;
            Variant variant = result.ViewData.Model as Variant;
            // Assert
            Assert.AreEqual(variant.ExperimentId, chosenExperimentId);
        }


        [TestMethod]
        public void CreateValidVariant()
        {
            //Arrange
            Variant newVariant = new Variant { VariantName = "VariantNew", Id = 7, ExperimentId=2 };

            //Act
            var result = (RedirectToRouteResult)_controller.Create(newVariant);
            //get list of all variants
            List<Variant> variants = variantRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(variants, newVariant);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }


        [TestMethod]
        public void CreateVariant_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("FakeError", "FakeError");
            Variant thisVariant = new Variant();
            //Act
            ViewResult result = _controller.Create(thisVariant) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditReturns_Is_Passed_Variant_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Edit(2,"");

            Variant variant = result.ViewData.Model as Variant;

            // Assert           
            Assert.AreEqual(variant, variant2);
        }

        [TestMethod]
        public void EditReturnsCorrectAction()
        {
            //Arrange

            //Act
            ViewResult result = _controller.Edit(2,"") as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditView_CorrectViewModelsReturned()
        {
            // Arrange

            // Act
            ViewResult result = _controller.Edit(1,"") as ViewResult;

            // Assert
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).Count, variantRepository.GetMetricModels().Count);
            Assert.AreEqual(((IList<MetricModel>)result.ViewBag.MetricModels).GetType(), variantRepository.GetMetricModels().GetType());           
            Assert.AreEqual(((IList<Experiment>)result.ViewBag.Experiments).Count, variantRepository.GetExperiments().Count);
            Assert.AreEqual(((IList<Experiment>)result.ViewBag.Experiments).GetType(), variantRepository.GetExperiments().GetType());

        }


        [TestMethod]
        public void EditVariantEditsModel()
        {
            //Arrange
            Variant editedVariant = new Variant { VariantName = "VariantEdited", Id = 1, ExperimentId=2};
            //Act           
            var result = (RedirectToRouteResult)_controller.Edit(editedVariant);
            //get list of all variants
            List<Variant> variants = variantRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.Contains(variants, editedVariant);
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditVariant_ValidationErrorReturnsCorrectActionAndView()
        {
            //Arrange
            _controller.ModelState.AddModelError("fakeError", "fakeError");
            Variant variant = new Variant();
            //Act
            ViewResult result = _controller.Edit(variant) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewBag.Action);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Is_Passed_Variant_Data()
        {
            // Arrange            

            // Act
            ViewResult result = (ViewResult)_controller.Delete(3);

            Variant variant = result.ViewData.Model as Variant;

            // Assert           
            Assert.AreEqual(variant, variant3);
        }


        [TestMethod]
        public void DeleteVariantDeletesModel()
        {
            //Arrange

            //Act           
            var result = (RedirectToRouteResult)_controller.DeleteConfirmed(3);
            //get list of all variants
            List<Variant> variants = variantRepository.LoadList(string.Empty);

            // Assert
            CollectionAssert.DoesNotContain(variants, variant3);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
