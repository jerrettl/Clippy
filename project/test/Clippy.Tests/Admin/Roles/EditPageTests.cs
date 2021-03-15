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
    }
}
