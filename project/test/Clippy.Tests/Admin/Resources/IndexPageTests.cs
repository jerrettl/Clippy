using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Resources
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfResources()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedResources = DatabaseInitializer.GetSeedingResources();
            mockContext.Setup(
                db => db.GetResourcesAsync()).Returns(Task.FromResult(expectedResources));
            var pageModel = new IndexModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync();

            // Assert
            var actualResources = Assert.IsAssignableFrom<List<Resource>>(pageModel.Resources);
            Assert.Equal(
                expectedResources.OrderBy(r => r.Id).Select(r => r.Location),
                actualResources.OrderBy(r => r.Id).Select(r => r.Location));
        }
    }
}
