# Optivem.Atomiv.Template

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

## Execution

Execute the following script in powershell:
.\run.ps1

This script will apply database migrations, run the REST API and also start up the swagger page.
Go to https://localhost:5101/swagger and run some swagger commands.

## Entity Framework

Update database
dotnet ef database update --project .\src\Tools\Optivem.Atomiv.Template.Tools.Migrator