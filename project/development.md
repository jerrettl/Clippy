# Development

The initial Clippy project was created using the built-in ASP.NET Core website template that uses React.

```ps
$ dotnet new react -n Clippy
```

The following technologies are used in the project:

- Microsoft Entity Framework Core

### Microsoft Entity Framework Core (EF Core)
EF Core is responsible for all data access to and from the database. To keep it simple, the project is using a SQLite database, which can optionally be changed to another database if so desired. The `Microsoft.EntityFrameworkCore.Sqlite` package is part of the project.

EF Core uses a custom `DbContext` Class, which we have called `ClippyContext`.

This has been added to the ASP.NET Core dependency injection framework in `Startup.cs`, making it globally available throughout the project.

```csharp
services.AddDbContext<ClippyContext>();
```

In addition, data migrations have been implemented in the project to manage and version the database schema. Data migrations uses an additional package, `Microsoft.EntityFrameworkCore.Design`, which is also included in the project.

In order to manually run data migrations and update the database, the EF Core Tools must be installed on the development machine.

```ps
$ dotnet tool install --global dotnet-ef
```

Once the tools are installed, one can create the database using the following command from the `Clippy` project folder. The migrations applied will vary as the project evolves.

```ps
$ dotnet ef database update

Build started...
Build succeeded.
Applying migration '20210217152705_InitalCreate'.
Done.
```

One can learn more about EF Core and migrations at the following resources:
- [EF Core](https://docs.microsoft.com/en-us/ef/core/)
- [EF Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [Data Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
