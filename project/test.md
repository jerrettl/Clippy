# Testing

Clippy includes a `Clippy.Tests` project for testing. It uses the [xUnit](https://xunit.net/) test framework and was initially created using the `xUnit` project template.

```ps
$ dotnet new xunit -n Clippy.Tests
```

One can manually run tests using the following .NET CLI command from the shell as mentioned in [Getting Started](readme.md).

```ps
$ dotnet test
```

Tests will generally follow the arrange, act, and assert method.

```csharp
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
```

One can learn more about testing with `xUnit` at the following resource:
- [Unit test controller logic in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-5.0)
