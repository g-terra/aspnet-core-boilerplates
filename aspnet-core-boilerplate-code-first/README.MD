# ASP.NET CORE BOILERPLATE
## CODE FIRST APPROACH

This project provides initial code for a asp.net core API project with code first approach using Entity framework

following non default dependencies were added:
- Microsoft.EntityFrameworkCore 6.0.13
- Microsoft.EntityFrameworkCore.tools 6.0.13
- Microsoft.EntityFrameworkCore.SqlServer 6.0.13
- Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore
- AspNetCore.HealthChecks.SqlServer
- Newtonsoft.Json

To run the project in development mode, it is necessary to first run the command
it will start a instance of MS SQL
```shell 
make dev-db-up
```

to stop the instance

```shell 
make dev-db-down
```


### dotnet cli command:

- to create a new migration:
```shell
dotnet ef migrations add {{NameOfMigration}}
```

- to update the database with accordingly to the migrations:
```shell
dotnet ef database update
```






