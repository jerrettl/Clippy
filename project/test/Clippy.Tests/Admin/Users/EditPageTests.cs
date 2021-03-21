using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
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
using Microsoft.Extensions.Logging;
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
            var mockLogger = new Mock<ILogger<EditModel>>();
            var expectedUser = DatabaseInitializer.GetSeedingUsers().Single(u => u.Id == userId);
            mockContext.Setup(
                db => db.GetUserAsync(userId)).Returns(Task.FromResult(expectedUser));
            var pageModel = new EditModel(mockContext.Object, mockLogger.Object);

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
            var mockLogger = new Mock<ILogger<EditModel>>();
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
            var pageModel = new EditModel(mockContext.Object, mockLogger.Object)
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

        [Theory]
        [InlineData(1, "Clippy6")]
        public async Task OnPostAsync_ReturnsAPageResult_WhenChangedUsernameExists(int existingUserId, string otherUsername)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var mockLogger = new Mock<ILogger<EditModel>>();
            var existingUser = DatabaseInitializer.GetSeedingUsers().Single(u => u.Id == existingUserId);
            var otherUser = new User { Username = otherUsername, Name = existingUser.Username};
            mockContext.Setup(db => db.GetUserAsync(existingUser.Id)).Returns(Task.FromResult(existingUser));
            mockContext.Setup(db => db.GetUserByUsernameAsync(otherUsername)).Returns(Task.FromResult(otherUser));
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
            var pageModel = new EditModel(mockContext.Object, mockLogger.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext),
                UserEntity = new EditUserModel {Username = otherUsername, Name = existingUser.Name}
            };

            // Act
            var result = await pageModel.OnPostAsync(existingUserId);

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}
