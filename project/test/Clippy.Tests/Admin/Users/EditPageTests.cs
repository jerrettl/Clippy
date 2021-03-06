using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Models.Admin;
using Clippy.Pages.Admin.Users;
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

namespace Clippy.Tests.Admin.Users
{
    public class EditPageTests
    {
        [Theory]
        [InlineData(1)]
        public async Task OnGetAsync_PopulatesThePageModel_WithAUser(int userId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedUser = DatabaseInitializer.GetSeedingUsers().Single(u => u.Id == userId);
            mockContext.Setup(
                db => db.GetUserAsync(userId)).Returns(Task.FromResult(expectedUser));
            var pageModel = new EditModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync(userId);

            // Assert
            var actualUser = Assert.IsAssignableFrom<EditUserModel>(pageModel.UserEntity);
            Assert.Equal(expectedUser.Username, actualUser.Username);
        }

        [Theory]
        [InlineData(1)]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelStateIsInvalid(int userId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedUser = DatabaseInitializer.GetSeedingUsers().Single(u => u.Id == userId);
            mockContext.Setup(db => db.GetUserAsync(userId)).Returns(Task.FromResult(expectedUser));
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
            pageModel.ModelState.AddModelError("Username", "Username is required.");

            // Act
            var result = await pageModel.OnPostAsync(userId);

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}
