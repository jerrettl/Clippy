using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Models.Admin;
using Clippy.Pages.Admin.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Resources
{
    public class AddPageTests
    {
        [Fact]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResources = DatabaseInitializer.GetSeedingResources();
            mockContext.Setup(db => db.GetResourcesAsync()).Returns(Task.FromResult(expectedResources));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new AddModel(mockContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            pageModel.ModelState.AddModelError("Title", "Title is required.");

            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Theory]
        [InlineData("NatGeo", "https://www.nationalgeographic.com")]
        [InlineData("Yellow", "https://www.nps.gov/yell/index.htm")]
        [InlineData("Foodie", "https://www.foodnetwork.com")]
        [InlineData("Lemons", "https://www.loveandlemons.com")]
        [InlineData("Hiking", "https://appalachiantrail.org")]
        [InlineData("Space", "https://www.spacex.com")]
        public async Task OnPostAsync_ReturnsAPageResult_WhenResourceLocationExists(string title, string location)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Location == location);
            mockContext.Setup(db => db.GetResourceByLocationAsync(location)).Returns(Task.FromResult(expectedResource));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new AddModel(mockContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext),
                Resource = new AddResourceModel {Title = title, Location = location}
            };

            // Act
            var result = await pageModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}
