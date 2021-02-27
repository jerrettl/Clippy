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
    }
}
