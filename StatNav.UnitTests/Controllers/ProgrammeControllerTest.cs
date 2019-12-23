using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatNav.WebApplication.Controllers;
using System.Web.Mvc;
using Moq;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Models;
using StatNav.WebApplication.Interfaces;

namespace StatNav.UnitTests.Controllers
{
    [TestClass]
    public class ProgrammeControllerTest
    {
        private ProgrammeController _controller;
        Mock<IProgrammeUnitOfWork> _mockRepository;
        List<ExperimentProgramme> _programmes;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IProgrammeUnitOfWork>();
            _programmes = new List<ExperimentProgramme>();
            _controller = new ProgrammeController();

        }

        [TestMethod]
        public void ProgrammeDetailView_Is_Passed_Programme_Data()
        {
            // Arrange
            _programmes.Add(new ExperimentProgramme() { Name = "Programme0" });
            _programmes.Add(new ExperimentProgramme() { Name = "Programme1" });
            _programmes.Add(new ExperimentProgramme() { Name = "Programme2" });
            _mockRepository.Setup(x => x.ProgrammeRepository.Load(It.IsAny<int>())).Returns((int i) => _programmes[i]);

            // Act
            ViewResult result = (ViewResult)_controller.Details(1);

            ExperimentProgramme ep = result.ViewData.Model as ExperimentProgramme;

            // Assert
            Assert.IsNotNull(ep, "The model used should be an Experient Programme");
            Assert.AreEqual("Forum1", ep.Name);
        }

        [TestMethod]
        public void IndexViewBag()
        {
            // Arrange
            ProgrammeController controller = new ProgrammeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.AreEqual("Programme", result.ViewBag.SelectedType);
        }

        [TestMethod]
        public void TestDetailView()
        {
            var controller = new ProgrammeController();
            var result = controller.Details(7) as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestProgrammeCreate()
        {

            ExperimentProgramme ep = new ExperimentProgramme { };

           
            var result = _controller.Create(ep) as ViewResult;
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void TestProgrammeDelete()
        {
            //Mock<StatNavContext> db = new Mock<StatNavContext>();
            
            var controller = new ProgrammeController();
            var db = new StatNavContext();
            var testData = new StatNavTestData();
            var programmeCount = testData.Get();
            var result = controller.Details(7) as ViewResult;
            Assert.IsNotNull(result);

        }

    }
}
