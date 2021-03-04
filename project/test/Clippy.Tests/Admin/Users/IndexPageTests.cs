using Clippy.Data;
using Clippy.Entities;
using Clippy.Pages.Admin.Users;
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

namespace Clippy.Tests.Admin.Users
{
    public class IndexPageTests
    {
        [Fact]
        public async Task OnGetAsync_PopulatesThePageModel_WithAListOfUsers()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ClippyContext>()
                .UseInMemoryDatabase("InMemoryDb");
            var mockContext = new Mock<ClippyContext>(optionsBuilder.Options);
            var expectedUsers = new List<User> {
                new User {Id = 1, Username = "Clippy", Name="Clippy Junior", CreateDate = DateTime.UtcNow}
            };
            mockContext.Setup(
                db => db.GetUsersAsync()).Returns(Task.FromResult(expectedUsers));
            var pageModel = new IndexModel(mockContext.Object);

            // Act
            await pageModel.OnGetAsync();

            // Assert
            var actualUsers = Assert.IsAssignableFrom<List<User>>(pageModel.Users);
            Assert.Equal(
                expectedUsers.OrderBy(u => u.Id).Select(u => u.Username),
                actualUsers.OrderBy(u => u.Id).Select(u => u.Username));
        }
    }
}
