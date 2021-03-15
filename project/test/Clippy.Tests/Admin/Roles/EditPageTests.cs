using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Models.Admin;
using Clippy.Pages.Admin.Roles;
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

namespace Clippy.Tests.Admin.Roles
{
    public class EditPageTests
    {
        [Theory]
        [InlineData(1)]
        public async Task OnGetAsync_PopulatesThePageModel_WithARole(int roleId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedRole = DatabaseInitializer.GetSeedingRoles().Single(r => r.Id == roleId);
            mockContext.Setup(
                db => db.GetRoleAsync(roleId)).Returns(Task.FromResult(expectedRole));
            var pageModel = new EditModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync(roleId);

            // Assert
            var actualRole = Assert.IsAssignableFrom<EditRoleModel>(pageModel.Role);
            Assert.Equal(expectedRole.Name, actualRole.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task OnPostAsync_ReturnsAPageResult_WhenModelStateIsInvalid(int roleId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedRole = DatabaseInitializer.GetSeedingRoles().Single(r => r.Id == roleId);
            mockContext.Setup(db => db.GetRoleAsync(roleId)).Returns(Task.FromResult(expectedRole));
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
            pageModel.ModelState.AddModelError("Name", "Name is required.");

            // Act
            var result = await pageModel.OnPostAsync(roleId);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Theory]
        [InlineData(1, "Contributor")]
        public async Task OnPostAsync_ReturnsAPageResult_WhenChangedRoleNameExists(int existingRoleId, string otherRoleName)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var existingRole = DatabaseInitializer.GetSeedingRoles().Single(r => r.Id == existingRoleId);
            var otherRole = new Role { Name = existingRole.Name};
            mockContext.Setup(db => db.GetRoleAsync(existingRole.Id)).Returns(Task.FromResult(existingRole));
            mockContext.Setup(db => db.GetRoleByNameAsync(otherRoleName)).Returns(Task.FromResult(otherRole));
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
                Role = new EditRoleModel {Name = otherRoleName}
            };

            // Act
            var result = await pageModel.OnPostAsync(existingRoleId);

            // Assert
            Assert.IsType<PageResult>(result);
        }
    }
}
