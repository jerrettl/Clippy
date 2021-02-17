using Clippy.Controllers.Api;
using System;
using Xunit;

namespace Clippy.Tests.Api
{
    public class StatusControllerTests
    {
        [Fact]
        public void Get_ShouldReturn_Ok()
        {
            // Arrange
            var controller = new StatusController();

            // Act
            var status = controller.Get();

            // Assert
            Assert.Equal("Ok", status);
        }
    }
}
