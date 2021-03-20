using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Pages.Admin.Bookmarks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Bookmarks
{
    public class DetailsPageTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task OnGetAsync_PopulatesThePageModel_WithABookmark(int bookmarkId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedBookmark = DatabaseInitializer.GetSeedingBookmarks().Single(b => b.Id == bookmarkId);
            mockContext.Setup(
                db => db.GetBookmarkAsync(bookmarkId)).Returns(Task.FromResult(expectedBookmark));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };

            // Act
            await pageModel.OnGetAsync(bookmarkId);

            // Assert
            var actualBookmark = Assert.IsAssignableFrom<Bookmark>(pageModel.Bookmark);
            Assert.Equal(expectedBookmark.Id, actualBookmark.Id);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageResult(int bookmarkId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedBookmark = DatabaseInitializer.GetSeedingBookmarks().Single(b => b.Id == bookmarkId);
            mockContext.Setup(
                db => db.GetBookmarkAsync(bookmarkId)).Returns(Task.FromResult(expectedBookmark));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };

            // Act
            var result = await pageModel.OnPostDeleteAsync(bookmarkId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }

        [Theory]
        [InlineData(100000000)]
        [InlineData(200000000)]
        [InlineData(300000000)]
        [InlineData(400000000)]
        public async Task OnPostDeleteAsync_ReturnsARedirectToPageWhenBookmarkDoesntExist(int bookmarkId)
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            mockContext.Setup(
                db => db.GetBookmarkAsync(bookmarkId)).Returns(Task.FromResult((Bookmark)null));
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageModel = new DetailsModel(mockContext.Object)
            {
                TempData = tempData    
            };

            // Act
            var result = await pageModel.OnPostDeleteAsync(bookmarkId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
        }
    }
}
