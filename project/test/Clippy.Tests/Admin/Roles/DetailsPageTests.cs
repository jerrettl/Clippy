using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Pages.Admin.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Roles
{
    public class DetailsPageTests
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
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync(roleId);

            // Assert
            var actualRole = Assert.IsAssignableFrom<Role>(pageModel.Role);
            Assert.Equal(expectedRole.Name, actualRole.Name);
        }

        [Theory]
        [InlineData(1)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageResult(int roleId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedRole = DatabaseInitializer.GetSeedingRoles().Single(r => r.Id == roleId);
            mockContext.Setup(
                db => db.GetRoleAsync(roleId)).Returns(Task.FromResult(expectedRole));
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            var result = await pageModel.OnPostDeleteAsync(roleId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Theory]
        [InlineData(100000000)]
        [InlineData(200000000)]
        [InlineData(300000000)]
        [InlineData(400000000)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageWhenRoleDoesntExist(int roleId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            mockContext.Setup(
                db => db.GetRoleAsync(roleId)).Returns(Task.FromResult((Role)null));
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            var result = await pageModel.OnPostDeleteAsync(roleId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}
