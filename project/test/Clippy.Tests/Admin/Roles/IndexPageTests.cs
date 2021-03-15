using Clippy.Data;
using Clippy.Data.Helpers;
using Clippy.Entities;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Clippy.Tests.Admin.Roles
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfRoles()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedRoles = DatabaseInitializer.GetSeedingRoles();
            mockContext.Setup(
                db => db.GetRolesAsync()).Returns(Task.FromResult(expectedRoles));
            var pageModel = new IndexModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync();

            // Assert
            var actualRoles = Assert.IsAssignableFrom<List<Role>>(pageModel.Roles);
            Assert.Equal(
                expectedRoles.OrderBy(r => r.Id).Select(r => r.Name),
                actualRoles.OrderBy(r => r.Id).Select(r => r.Name));
        }
    }
}
