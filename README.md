## Optivem Framework

[![Build Status](https://img.shields.io/appveyor/ci/optivem/framework-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/framework-dotnetcore)
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
PM> dotnet new -i Optivem.Template
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



<a name="technical-reference" />
## Technical Reference

<a name="core-packages" />
### Core Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common) Optivem.Framework.Core.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Domain.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Domain) Optivem.Framework.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Application.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Application) Optivem.Framework.Core.Application
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Application.Interface.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Application.Interface) Optivem.Framework.Core.Application.Interface
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.All.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.All) Optivem.Framework.Core.All

<a name="infrastructure-packages" />
### Infrastructure Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.AspNetCore) Optivem.Framework.Infrastructure.AspNetCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.AutoMapper) Optivem.Framework.Infrastructure.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.CsvHelper.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.CsvHelper) Optivem.Framework.Infrastructure.CsvHelper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.EntityFrameworkCore) Optivem.Framework.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.FluentValidation) Optivem.Framework.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.MediatR.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.MediatR) Optivem.Framework.Infrastructure.MediatR
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.NewtonsoftJson) Optivem.Framework.Infrastructure.NewtonsoftJson
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Selenium.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Selenium) Optivem.Framework.Infrastructure.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.System.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.System) Optivem.Framework.Infrastructure.System
	
<!-- Infrastructure.EPPlus -->
	
<a name="dependency-injection-packages" />
### Dependency Injection Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Common.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Common) Optivem.Framework.DependencyInjection.Common

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Core.Domain.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Core.Domain) Optivem.Framework.DependencyInjection.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Core.Application.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Core.Application) Optivem.Framework.DependencyInjection.Core.Application

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper) Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore) Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation) Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Infrastructure.MediatR.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Infrastructure.MediatR) Optivem.Framework.DependencyInjection.Infrastructure.MediatR
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson) Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson


    <!-- 
	Infrastructure.AspNetCore
	'src\DependencyInjection\Infrastructure\CsvHelper\Optivem.Framework.DependencyInjection.Infrastructure.CsvHelper.csproj',		
    # 'src\DependencyInjection\Infrastructure\EPPlus\Optivem.Framework.DependencyInjection.Infrastructure.EPPlus.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Optivem.Framework.DependencyInjection.Infrastructure.Selenium.csproj',		
    # 'src\DependencyInjection\Infrastructure\System\Optivem.Framework.DependencyInjection.Infrastructure.System.csproj',	
	-->

<a name="web-packages" />
### Web Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Web.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Web.AspNetCore) Optivem.Framework.Web.AspNetCore

<a name="test-packages" />
### Test Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.AspNetCore) Optivem.Framework.Test.AspNetCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.EntityFrameworkCore) Optivem.Framework.Test.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.FluentAssertions.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.FluentAssertions) Optivem.Framework.Test.FluentAssertions
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.MicrosoftExtensions.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.MicrosoftExtensions) Optivem.Framework.Test.MicrosoftExtensions
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.Selenium.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.Selenium) Optivem.Framework.Test.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.Xunit.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.Xunit) Optivem.Framework.Test.Xunit


<a name="support" />
## Getting support

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/framework-dotnetcore/issues](https://github.com/optivem/framework-dotnetcore/issues).

<a name="license" />
## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.