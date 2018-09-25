using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using ComputerComponentsWeb.Controllers;
using Moq;
using EF.ComponentData.Services;
using EF.ComponentData.Models;
using ComputerComponentsWeb.Helpers;
using System.Web;
using System.Web.Routing;

namespace ComputerComponents.Tests.Controllers
{
    [TestFixture]
    public class ComponentSummaryControllerTest
    {
        private Mock<UserComponentSummaryService> _userComponentSummaryService;
        private Mock<SessionHelper> _sessionHelper;
        private Mock<HttpContextBase> _httpContext;
        private Mock<HttpRequestBase> _request;

        private void SetupTests()
        {
            _userComponentSummaryService = new Mock<UserComponentSummaryService>();
            _sessionHelper = new Mock<SessionHelper>();
            _httpContext = new Mock<HttpContextBase>();
            _request = new Mock<HttpRequestBase>();

            _httpContext.Setup(x => x.Request).Returns(_request.Object);
        }

        [Test]
        public void Index()
        {
            // Arrange            
            var userId = Guid.NewGuid();

            SetupTests();

            _userComponentSummaryService.Setup(m => m.FindComponentItemListByUser(userId.ToString())).Returns(new List<UserComponentSummary>
            {
                new UserComponentSummary { ID=1, UserId = userId, ComponentItem = new ComponentItem { ID=1, Name="Test1", Description="Description1", Price=300, Rating=4 }  },
                new UserComponentSummary { ID=1, UserId = userId, ComponentItem = new ComponentItem { ID=2, Name="Test2", Description="Description2", Price=400, Rating=4 }  },
                new UserComponentSummary { ID=1, UserId = userId, ComponentItem = new ComponentItem { ID=3, Name="Test3", Description="Description3", Price=500, Rating=4 }  },
                new UserComponentSummary { ID=1, UserId = userId, ComponentItem = new ComponentItem { ID=4, Name="Test4", Description="Description4", Price=600, Rating=4 }  }
            });

            _httpContext.Setup(x => x.Request).Returns(_request.Object);

            _sessionHelper.Setup(m => m.GetUserId(_httpContext.Object)).Returns(userId.ToString());

            ComponentSummaryController controller = new ComponentSummaryController(_userComponentSummaryService.Object);
            controller.CtrlSessionHelper = _sessionHelper.Object;

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddComponentSummaryItem()
        {
            // Arrange
            var id = 1;
            var categoryCode = "TestCategory1";
            var userId = Guid.NewGuid();            

            SetupTests();

            _userComponentSummaryService.Setup(m => m.AddUserComponentSummaryItem(id, userId.ToString())).Returns(new UserComponentSummary
            {
                ID = 1,
                UserId = userId,
                ComponentItem = new ComponentItem { ID = 1, Name = "Test1", Description = "Description1", Price = 300, Rating = 4 }
            });
                        
            _sessionHelper.Setup(m => m.GetUserId(_httpContext.Object)).Returns(userId.ToString());

            ComponentSummaryController controller = new ComponentSummaryController(_userComponentSummaryService.Object)
            {
                CtrlSessionHelper = _sessionHelper.Object
            };
            RequestContext rc = new RequestContext(_httpContext.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(rc, controller);

            // Act
            RedirectToRouteResult result = controller.AddComponentSummaryItem(id, categoryCode) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("ListComponents", result.RouteValues["action"].ToString());
            Assert.AreEqual("Home", result.RouteValues["controller"].ToString());            
        }

        [Test]
        public void RemoveComponentSummaryItem()
        {
            // Arrange
            var id = 1;
            var price = 100;
            var userId = Guid.NewGuid();

            SetupTests();

            _userComponentSummaryService.Setup(m => m.RemoveUserComponentSummaryItem(id));
            _sessionHelper.Setup(m => m.GetUserId(_httpContext.Object)).Returns(userId.ToString());

            ComponentSummaryController controller = new ComponentSummaryController(_userComponentSummaryService.Object)
            {
                CtrlSessionHelper = _sessionHelper.Object
            };
            RequestContext rc = new RequestContext(_httpContext.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(rc, controller);

            // Act
            RedirectToRouteResult result = controller.RemoveComponentSummaryItem(id, price) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"].ToString());            
        }
    }
}
