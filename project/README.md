# Clippy

Clippy is a social bookmarking app. It consists of a frontend website built using ReactJS and an API built using ASP.NET Core.

## Requirements

Clippy requires .NET 5 and Node.js. To create the database, you will also need Entity Framework Core (EF Core) Tools installed.

You can verify the version of .NET you are running using the following command.

```ps
$ dotnet --version
5.0.102
```

You can verify the version of Node.js you are running using this command.

```ps
$ node --version
v14.15.5
```

Install the latest EF Core Tools if they are not installed already.

```ps
$ dotnet tool install --global dotnet-ef
```

## Getting Started

Clone the `Clippy` GitHub repository to a local folder.

```ps
https://github.com/Clippy5/Clippy.git
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
https://localhost:5001/swagger
```
