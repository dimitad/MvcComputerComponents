using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using ComputerComponentsWeb.Controllers;
using Moq;
using EF.ComponentData.Services;
using EF.ComponentData.Models;

namespace ComputerComponents.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private Mock<ComponentCategoryService> _mockCategoryService;
        private Mock<ComponentItemService> _mockItemService;

        private void SetupTests()
        {
            _mockCategoryService = new Mock<ComponentCategoryService>();
            _mockItemService = new Mock<ComponentItemService>();
        }

        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetCategoryList()
        {
            //// Arrange
            SetupTests();

            _mockCategoryService.Setup(m => m.GetAllComponentCategories()).Returns(new List<ComponentCategory>
            {
                new ComponentCategory { ID=1, CategoryCode="cat1", Name="Category1", Position=1, ComponentItems=null},
                new ComponentCategory { ID=1, CategoryCode="cat2", Name="Category2", Position=2, ComponentItems=null},
                new ComponentCategory { ID=1, CategoryCode="cat3", Name="Category3", Position=3, ComponentItems=null},
                new ComponentCategory { ID=1, CategoryCode="cat4", Name="Category4", Position=4, ComponentItems=null},
                new ComponentCategory { ID=1, CategoryCode="cat5", Name="Category5", Position=5, ComponentItems=null},
            });

            HomeController controller = new HomeController(_mockCategoryService.Object, _mockItemService.Object);

            //// Act
            PartialViewResult result = controller.GetCategoryList() as PartialViewResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ListComponents()
        {
            //// Arrange
            SetupTests();
            var categoryCode = "testCategory";

            _mockItemService.Setup(m => m.GetComponentItemsByCategoryCode(categoryCode)).Returns(new List<ComponentItem>
            {
                new ComponentItem { ID=1, Name="Test1", Description="Description1", Price=300, Rating=4 },
                new ComponentItem { ID=2, Name="Test2", Description="Description2", Price=400, Rating=4 },
                new ComponentItem { ID=3, Name="Test3", Description="Description3", Price=500, Rating=4 },
            });

            _mockCategoryService.Setup(m => m.GetComponentCategoryByCode(categoryCode)).Returns(new ComponentCategory
            {
                ID = 1,
                CategoryCode = "test1",
                Name = "Test1",
                Position = 1
            });

            HomeController controller = new HomeController(_mockCategoryService.Object, _mockItemService.Object);

            //// Act
            ViewResult result = controller.ListComponents(categoryCode) as ViewResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test1", result.ViewBag.CategoryName);
        }
    }
}
