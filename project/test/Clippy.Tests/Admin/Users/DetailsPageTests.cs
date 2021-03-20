using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Pages.Admin.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Users
{
    public class DetailsPageTests
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
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };

            // Act
            await pageModel.OnGetAsync(userId);

            // Assert
            var actualUser = Assert.IsAssignableFrom<User>(pageModel.UserEntity);
            Assert.Equal(expectedUser.Username, actualUser.Username);
        }

        [Theory]
        [InlineData(1)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageResult(int userId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedUser = DatabaseInitializer.GetSeedingUsers().Single(u => u.Id == userId);
            mockContext.Setup(
                db => db.GetUserAsync(userId)).Returns(Task.FromResult(expectedUser));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };
            pageModel.UnitTesting = true;

            // Act
            var result = await pageModel.OnPostDeleteAsync(userId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Theory]
        [InlineData(100000000)]
        [InlineData(200000000)]
        [InlineData(300000000)]
        [InlineData(400000000)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageWhenUserDoesntExist(int userId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            mockContext.Setup(
                db => db.GetUserAsync(userId)).Returns(Task.FromResult((User)null));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };
            pageModel.UnitTesting = true;

            // Act
            var result = await pageModel.OnPostDeleteAsync(userId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}
