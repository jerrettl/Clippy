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
    public class EditPageTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task OnGetAsync_PopulatesThePageModel_WithAResource(int resourceId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Id == resourceId);
            mockContext.Setup(
                db => db.GetResourceAsync(resourceId)).Returns(Task.FromResult(expectedResource));
            var pageModel = new EditModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync(resourceId);

            // Assert
            var actualResource = Assert.IsAssignableFrom<EditResourceModel>(pageModel.Resource);
            Assert.Equal(expectedResource.Location, actualResource.Location);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelStateIsInvalid(int resourceId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Id == resourceId);
            mockContext.Setup(db => db.GetResourceAsync(resourceId)).Returns(Task.FromResult(expectedResource));
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
            var pageModel = new EditModel(mockContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };
            pageModel.ModelState.AddModelError("Title", "Title is required.");

            // Act
            var result = await pageModel.OnPostAsync(resourceId);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Theory]
        [InlineData(1, "https://www.spacex.com")]
        [InlineData(2, "https://www.nationalgeographic.com")]
        [InlineData(3, "https://www.nationalgeographic.com")]
        [InlineData(4, "https://www.nationalgeographic.com")]
        [InlineData(5, "https://www.nationalgeographic.com")]
        [InlineData(6, "https://www.nationalgeographic.com")]
        public async Task OnPostAsync_ReturnsAPageResult_WhenResourceLocationExists(int id, string existingLocation)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var idResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Id == id);
            var locationResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Location == existingLocation);
            mockContext.Setup(db => db.GetResourceAsync(id)).Returns(Task.FromResult(idResource));
            mockContext.Setup(db => db.GetResourceByLocationAsync(existingLocation)).Returns(Task.FromResult(locationResource));
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
            var pageModel = new EditModel(mockContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext),
                Resource = new EditResourceModel {Title = "1234567890", Location = existingLocation}
            };

            // Act
            var result = await pageModel.OnPostAsync(id);

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}
