# Clippy

Clippy is a social bookmarking app built using ASP.NET Core Razor Pages and Entity Framework Core (EF Core).

## Requirements

Clippy requires .NET 5. To create the database, you will also need EF Core Tools installed.

You can verify the version of .NET you are running using the following command.

```ps
$ dotnet --version
5.0.102
```

Install the latest EF Core Tools if they are not installed already.

```ps
$ dotnet tool install --global dotnet-ef
```

## OAuth

Clippy uses GitHub OAuth for authentication by default. You are free to add additional providers and change the default scheme.

To use the existing provider you will need to create an OAuth Application in your GitHub Account and store the **ClientId** and **ClientSecret** as user secrets. For security reasons, this information has not been provided in the configuration settings.

You set the user secrets by navigating to the `project/src/Clippy` folder and executing the following commands.

```ps
$ dotnet user-secrets set "GitHub:ClientId" "{Your ClientId}"
$ dotnet user-secrets set "GitHub:ClientSecret" "{Your ClientSecret}"
```

You can learn more about securing secrets in .NET Core from the following article.

[Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)

Failure to make the **ClientId** and **ClientSecret** available to Clippy will cause a runtime error.

## Getting Started

Clone the `Clippy` GitHub repository to a local folder.

```ps
$ git clone https://github.com/Clippy5/Clippy.git
```

Navigate inside the `project` folder where `Clippy.sln` is located to build and test the Clippy solution.

```ps
$ dotnet build
$ dotnet test
```

Navigate to the `Clippy` source code folder.

```ps
$ cd src/clippy
```

Create the database using EF Core Tools.

```ps
$ dotnet ef database update
```

Run the application.

```ps
$ dotnet run --no-build

Now listening on: https://localhost:5001
```

Open a browser and navigate to the Clippy web application at

```
https://localhost:5001
```

Explore the Clippy API using Swagger UI.

```
https://localhost:5001/swagger/index.html
```

## Development

Visit [development.md](development.md) for more information on development.

## Testing

Visit [test.md](test.md) for more information on testing.
