using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
using Clippy.Pages.Admin.Bookmarks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Bookmarks
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfBookmarks()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedBookmarks = DatabaseInitializer.GetSeedingBookmarks();
            mockContext.Setup(
                db => db.GetBookmarksAsync()).Returns(Task.FromResult(expectedBookmarks));
            var pageModel = new IndexModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync();

            // Assert
            var actualBookmarks = Assert.IsAssignableFrom<List<Bookmark>>(pageModel.Bookmarks);
            Assert.Equal(
                expectedBookmarks.OrderBy(b => b.Id).Select(b => b.Id),
                actualBookmarks.OrderBy(b => b.Id).Select(b => b.Id));
        }
    }
}
