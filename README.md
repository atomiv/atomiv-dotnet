## Atomiv .NET

[![Build Status](https://img.shields.io/appveyor/ci/atomiv/atomiv-cs.svg)](https://ci.appveyor.com/project/atomiv/atomiv-cs)

<!--

[![Build Status](https://dev.azure.com/atomiv/Atomiv/_apis/build/status/atomiv.framework-dotnetcore?branchName=develop)](https://dev.azure.com/atomiv/Atomiv/_build/latest?definitionId=1&branchName=develop)
[![Build Status](https://dev.azure.com/atomiv/Atomiv/_apis/build/status/atomiv.framework-dotnetcore?branchName=master)](https://dev.azure.com/atomiv/Atomiv/_build/latest?definitionId=1&branchName=master)

-->

[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

Welcome to the Atomiv! The Atomiv was created to help you increase code quality, help you deliver products faster to customers and reduce your overall software development cost. This documentation page will show you how to get up-and-running with the Atomiv in your .NET Core 2.2 software projects. 

## Table of Contents

* [Introduction](#introduction)
* [Getting Started](#getting-started)
* [Technical Reference](#technical-reference)
* [Getting support](#support)
* [License](#license)

## Introduction

Atomiv was created to accelerate the development of enterprise applications, so that you can quickly create new projects for your customers.

The Atomiv is founded upon Clean Architecture principles and supports:
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

## Technical Reference

### Atomiv Core

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Core.Common.svg)](https://www.nuget.org/packages/Atomiv.Core.Common) Atomiv.Core.Common
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Core.Domain.svg)](https://www.nuget.org/packages/Atomiv.Core.Domain) Atomiv.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Core.Application.svg)](https://www.nuget.org/packages/Atomiv.Core.Application) Atomiv.Core.Application
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Core.Application.Interface.svg)](https://www.nuget.org/packages/Atomiv.Core.Application.Interface) Atomiv.Core.Application.Interface
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Core.All.svg)](https://www.nuget.org/packages/Atomiv.Core.All) Atomiv.Core.All

### Atomiv Infrastructure

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.AspNetCore.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.AspNetCore) Atomiv.Infrastructure.AspNetCore
* ~~[![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.AutoMapper) Atomiv.Infrastructure.AutoMapper~~ **[DEPRECATED - Use Atomiv.Infrastructure.Mapster instead]**
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.CsvHelper.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.CsvHelper) Atomiv.Infrastructure.CsvHelper
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.EntityFrameworkCore) Atomiv.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.FluentValidation) Atomiv.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.NewtonsoftJson) Atomiv.Infrastructure.NewtonsoftJson
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.Selenium.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.Selenium) Atomiv.Infrastructure.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Infrastructure.System.svg)](https://www.nuget.org/packages/Atomiv.Infrastructure.System) Atomiv.Infrastructure.System
	
<!-- Infrastructure.EPPlus -->

### Atomiv Dependency Injection

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Common.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Common) Atomiv.DependencyInjection.Common
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Core.Domain.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Core.Domain) Atomiv.DependencyInjection.Core.Domain
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Core.Application.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Core.Application) Atomiv.DependencyInjection.Core.Application
* ~~[![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Infrastructure.AutoMapper.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Infrastructure.AutoMapper) Atomiv.DependencyInjection.Infrastructure.AutoMapper~~ **[DEPRECATED - Use Atomiv.Infrastructure.Mapster instead]**
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore) Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Infrastructure.FluentValidation.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Infrastructure.FluentValidation) Atomiv.DependencyInjection.Infrastructure.FluentValidation
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson.svg)](https://www.nuget.org/packages/Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson) Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson


    <!-- 
	Infrastructure.AspNetCore
	'src\DependencyInjection\Infrastructure\CsvHelper\Atomiv.DependencyInjection.Infrastructure.CsvHelper.csproj',		
    # 'src\DependencyInjection\Infrastructure\EPPlus\Atomiv.DependencyInjection.Infrastructure.EPPlus.csproj',
    # 'src\DependencyInjection\Infrastructure\Selenium\Atomiv.DependencyInjection.Infrastructure.Selenium.csproj',		
    # 'src\DependencyInjection\Infrastructure\System\Atomiv.DependencyInjection.Infrastructure.System.csproj',	
	-->

### Atomiv Web

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Web.AspNetCore.svg)](https://www.nuget.org/packages/Atomiv.Web.AspNetCore) Atomiv.Web.AspNetCore

### Atomiv Test

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.AspNetCore.svg)](https://www.nuget.org/packages/Atomiv.Test.AspNetCore) Atomiv.Test.AspNetCore
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Atomiv.Test.EntityFrameworkCore) Atomiv.Test.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.FluentAssertions.svg)](https://www.nuget.org/packages/Atomiv.Test.FluentAssertions) Atomiv.Test.FluentAssertions
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.MicrosoftExtensions.svg)](https://www.nuget.org/packages/Atomiv.Test.MicrosoftExtensions) Atomiv.Test.MicrosoftExtensions
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.Selenium.svg)](https://www.nuget.org/packages/Atomiv.Test.Selenium) Atomiv.Test.Selenium
* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Test.Xunit.svg)](https://www.nuget.org/packages/Atomiv.Test.Xunit) Atomiv.Test.Xunit

### Atomiv Template

* [![NuGet](https://img.shields.io/nuget/v/Atomiv.Templates.svg)](https://www.nuget.org/packages/Atomiv.Templates) Atomiv.Templates

## Getting support

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the [Issue Tracker](https://github.com/atomiv/atomiv-cs/issues).

<a name="license" />

## Contributing

You can open up the solution Atomiv.sln and make edits on the develop branch (or pull request).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2020 [Atomiv](https://www.atomiv.com/) All Rights Reserved.
