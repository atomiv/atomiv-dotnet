## Optivem Framework

[![Build Status](https://img.shields.io/appveyor/ci/optivem/framework-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/framework-dotnetcore)
[![Build Status](https://dev.azure.com/optivem/Optivem%20Framework/_apis/build/status/optivem.framework-dotnetcore?branchName=develop)](https://dev.azure.com/optivem/Optivem%20Framework/_build/latest?definitionId=1&branchName=develop)
[![Build Status](https://dev.azure.com/optivem/Optivem%20Framework/_apis/build/status/optivem.framework-dotnetcore?branchName=master)](https://dev.azure.com/optivem/Optivem%20Framework/_build/latest?definitionId=1&branchName=master)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

Welcome to the Optivem Framework! The Optivem Framework was created to help you increase code quality, help you deliver products faster to customers and reduce your overall software development cost. This documentation page will show you how to get up-and-running with the Optivem Framework in your .NET Core 2.2 software projects. 

## Table of Contents

* [Introduction](#introduction)
* [Getting Started](#getting-started)
* [Technical Reference](#technical-reference)
* [Getting support](#support)
* [License](#license)

<a name="introduction" />
## Introduction

Optivem Framework was created to accelerate the development of enterprise applications, so that you can quickly create new projects for your customers.

The Optivem Framework is founded upon Clean Architecture principles and supports:
* Modularity & re-usability
* Extensibility & flexibility
* Maintainability & testibility
* Scalability and portability

The architecture consists of the following layers:
* Core Layer (contains Domain and Application)
* Infrastructure Layer (contains third-party libraries and frameworks, integration with external systems)
* Dependency Injection Layer (used to setup the compostion root)
* Web Layer (contains the REST API and presentation)
* Test Layer (contains Unit, Integration and System tests)

<a name="getting-started" />

## Getting started

We are using Visual Studio 2019 and .NET Core 2.2.


<a name="installation" />
### Installation

To install the Optivem Template:
1. Run Visual Studio
2. Open the Package Manager Console (Visual Studio main menu: Tools > NuGet Package Manager > Package Manager Console)
3. Run the following command inside the Package Manager Console

```ps
PM> dotnet new -i Optivem.Atomiv.Template
```

4. In the future, you can run this same command to get updated versions of the template

<a name="create-new-project" />
### Create a new project

To create a new project:
1. Run Visual Studio
2. Open the Package Manager Console (Visual Studio main menu: Tools > NuGet Package Manager > Package Manager Console)
3. Create the directory for your new project, for example: 

```ps
PM> mkdir C:\Users\Valentina.Cupac\source\repos\MyWebShop
```

4. Go inside the new directory:

```ps
PM> cd C:\Users\Valentina.Cupac\source\repos\MyWebShop
```
5. Create the Visual Studio Solution based on the Optivem Template:

```ps
PM> dotnet new optivem
```

6. Open the solution (Visual Studio main menu: File > Open Project/Solution, selecting the folder and inside it the solution MyWebShop.sln)

7. Rebuild the solution

8. Set MyWebShop.Web.RestApi as the StartUp project

9. Inside MyWebShop.Web.RestApi, open up the file appsettings.Development.json, you can adjust the DefaultConnection to the location where the database should be created

10. Inside the Package Manager Console, run the command to create the database:

```ps
PM> Update-Database
```

<!-- TODO: VC: Handle the warnings that appear -->

11. Run the application

12. Browser opens up https://localhost:44315/api/values

12. Go to the Swagger page https://localhost:44315/swagger/index.html where you can execute any API calls

13. Stop Debugging

14. Open up the Test Explorer (Visual Studio main menu: Test > Windows > Test Explorer)

15. Rebuild the solution to discover all the tests

15. Click on "Run All" inside the Test Explorer (all tests should pass)

<a name="running-cli" />
### Running via the CLI

Global setting to trust localhost certificates (used during development):

dotnet dev-certs https --trust
Then when there is a Security Warning dialog "Do you want to install this certificate", click on "Yes".

Then run the applications:

D:\GitHub\optivem\framework-dotnetcore\template\src\Web\RestApi>dotnet run MyWebShop.Web.RestApi.csproj
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\Valentina.Cupac\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
Hosting environment: Development
Content root path: D:\GitHub\optivem\framework-dotnetcore\template\src\Web\RestApi
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000

dotnet run Optivem.Atomiv.Template.Web.UI.csproj
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\Valentina.Cupac\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
Hosting environment: Development
Content root path: D:\GitHub\optivem\framework-dotnetcore\template\src\Web\UI
Now listening on: https://localhost:5003
Now listening on: http://localhost:5002
Application started. Press Ctrl+C to shut down.

In the browser, go to https://localhost:5003/customers

<a name="running-postman" />
### Running via Postman

Inside Postman, Settings > General > SSL Verification set to off.

Then when you run it via CLI (see above), https://localhost:5001/api/customers

<!-- TODO: VC: Give an example of POST, GET, PUT, GET, DELETE, GET -->


<a name="technical-reference" />
## Technical Reference

<a name="core-packages" />
### Optivem Framework Core

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Core.Common.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Core.Common) Optivem.Atomiv.Core.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Core.Domain.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Core.Domain) Optivem.Atomiv.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Core.Application.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Core.Application) Optivem.Atomiv.Core.Application
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Core.Application.Interface.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Core.Application.Interface) Optivem.Atomiv.Core.Application.Interface
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Core.All.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Core.All) Optivem.Atomiv.Core.All

<a name="infrastructure-packages" />
### Optivem Framework Infrastructure

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.AspNetCore) Optivem.Atomiv.Infrastructure.AspNetCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.AutoMapper) Optivem.Atomiv.Infrastructure.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.CsvHelper.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.CsvHelper) Optivem.Atomiv.Infrastructure.CsvHelper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.EntityFrameworkCore) Optivem.Atomiv.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.FluentValidation) Optivem.Atomiv.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.MediatR.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.MediatR) Optivem.Atomiv.Infrastructure.MediatR
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.NewtonsoftJson) Optivem.Atomiv.Infrastructure.NewtonsoftJson
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.Selenium.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.Selenium) Optivem.Atomiv.Infrastructure.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Infrastructure.System.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Infrastructure.System) Optivem.Atomiv.Infrastructure.System
	
<!-- Infrastructure.EPPlus -->
	
<a name="dependency-injection-packages" />
### Optivem Framework Dependency Injection

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Common.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Common) Optivem.Atomiv.DependencyInjection.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Core.Domain.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Core.Domain) Optivem.Atomiv.DependencyInjection.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Core.Application.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Core.Application) Optivem.Atomiv.DependencyInjection.Core.Application
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper) Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore) Optivem.Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Infrastructure.FluentValidation) Optivem.Atomiv.DependencyInjection.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR) Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson) Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson


    <!-- 
	Infrastructure.AspNetCore
	'src\DependencyInjection\Infrastructure\CsvHelper\Optivem.Atomiv.DependencyInjection.Infrastructure.CsvHelper.csproj',		
    # 'src\DependencyInjection\Infrastructure\EPPlus\Optivem.Atomiv.DependencyInjection.Infrastructure.EPPlus.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Optivem.Atomiv.DependencyInjection.Infrastructure.Selenium.csproj',		
    # 'src\DependencyInjection\Infrastructure\System\Optivem.Atomiv.DependencyInjection.Infrastructure.System.csproj',	
	-->

<a name="web-packages" />
### Optivem Framework Web

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Web.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Web.AspNetCore) Optivem.Atomiv.Web.AspNetCore

<a name="test-packages" />
### Optivem Framework Test

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.AspNetCore) Optivem.Atomiv.Test.AspNetCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.EntityFrameworkCore) Optivem.Atomiv.Test.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.FluentAssertions.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.FluentAssertions) Optivem.Atomiv.Test.FluentAssertions
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.MicrosoftExtensions.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.MicrosoftExtensions) Optivem.Atomiv.Test.MicrosoftExtensions
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.Selenium.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.Selenium) Optivem.Atomiv.Test.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Test.Xunit.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Test.Xunit) Optivem.Atomiv.Test.Xunit

### Optivem Template

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Atomiv.Template.svg)](https://www.nuget.org/packages/Optivem.Atomiv.Template) Optivem.Atomiv.Template

<a name="support" />
## Getting support

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/framework-dotnetcore/issues](https://github.com/optivem/framework-dotnetcore/issues).

<a name="license" />
## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.