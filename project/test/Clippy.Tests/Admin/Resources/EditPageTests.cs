using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Models.Admin;
using Clippy.Pages.Admin.Resources;
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
    }
}
