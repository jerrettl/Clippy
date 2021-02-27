using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Pages.Admin.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Resources
{
    public class DetailsPageTests
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
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync(resourceId);

            // Assert
            var actualResource = Assert.IsAssignableFrom<Resource>(pageModel.Resource);
            Assert.Equal(expectedResource.Location, actualResource.Location);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageResult(int resourceId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResource = DatabaseInitializer.GetSeedingResources().Single(r => r.Id == resourceId);
            mockContext.Setup(
                db => db.GetResourceAsync(resourceId)).Returns(Task.FromResult(expectedResource));
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            var result = await pageModel.OnPostDeleteAsync(resourceId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Theory]
        [InlineData(100000000)]
        [InlineData(200000000)]
        [InlineData(300000000)]
        [InlineData(400000000)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageWhenResourceDoesntExist(int resourceId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            mockContext.Setup(
                db => db.GetResourceAsync(resourceId)).Returns(Task.FromResult((Resource)null));
            var pageModel = new DetailsModel(mockContext.Object);

            // Act
            var result = await pageModel.OnPostDeleteAsync(resourceId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}
