# Optivem.Template

## Prerequisites

The following are the system prerequisites:

* .NET Core SDK 3.1
* Visual Studio Community 2019
* Microsoft SQL Server 2017
* Microsoft SQL Server Management Studio
* Postman (optional)

The following need to be installed:

* dotnet tool install --global dotnet-ef --version 3.1
* dotnet tool install --global dotnet-dev-certs

Development certificates need to be enabled:
* dotnet dev-certs https --trust

If using Postman (optional), then turn off SSL vertification when working locally:
* File > Settings > SSL certificate verification: OFF

## Migrations

dotnet ef database update --project .\src\Tools\Optivem.Template.Tools.Migrator

## Execution

dotnet run --project .\src\Web\Optivem.Template.Web.RestApi\Optivem.Template.Web.RestApi.csproj
start https://localhost:5101/swagger