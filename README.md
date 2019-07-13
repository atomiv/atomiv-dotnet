## Optivem Framework

[![Build Status](https://img.shields.io/appveyor/ci/optivem/framework-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/framework-dotnetcore)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

Welcome to the Optivem Framework! The Optivem Framework was created to help you increase code quality, help you deliver products faster to customers and reduce your overall software development cost. This documentation page will show you how to get up-and-running with the Optivem Framework in your .NET Core 2.2 software projects. 

## Table of Contents

[Introduction](#introduction):
* [A story from the trenches](#story)
* [What is the Optivem Framework?](#what)
* [Why should I use the Optivem Framework?](#why)


[Getting Started](#getting-started):
* [Installation](#installation)
* [Create your first project](#first-project)
* [Real-life sample projects](#sample-projects)

[Technical Reference](#technical-reference):

* [Architecture](#architecture)
* [Core Packages](#core-packages)
* [Infrastructure Packages](#infrastructure-packages)
* [Dependency Injection Packages](#dependency-injection-packages)
* [Web Packages](#web-packages)
* [Test Packages](#test-packages)

[Further Information](#further-information)
* [Getting support](#support)
* [MIT License](#license)

<a name="introduction" />
## Introduction

<a name="story" />
### A story from the trenches
At first, copy-paste is fine - it is faster in the short run. For example, let's say we started with some utility class for parsing text files. At first, it was all "simple", it was just reading a set of lines from the text file. This was developed in Project A. Then, Project B came along, where there was also the requirement for reading text files, so naturally the developer in Project B copied the code base from Project A. However, due to different requirements, parsing text files in Project B was a bit more complex, needed to handle different date formats depending on location settings, so the developer had to adapt the code. Then Project C came up, and there was also a requirement for reading from text files, but with the additional requirement that headers needed to be adjusted. 

Then a bug was found affecting base parsing functionality, and so then in all the projects A, B, C developers had to manually fix the bug. Afterwards, Project D came up and it had some requirements like Project A and some requirements like Project C, so then the developer copied some parts from Project A, some parts from Project C, and combined it together. Furthermore, some newcomers joined the team and when they had to implement text parsing, the other team members told them what was implemented on one project, was was on another, so the developers often had to search through multiple projects.

Now we see that, as the number of project grows and as the codebase grows, that the copy-paste solution is not really maintainable. Reasons are because when creating new projects, develoeprs have to search for older projects to copy the code from, and when bugs are found, it needs to be solved multiple times. This increases overall development cost, introduces risk and decreases quality. So with this in mind, it introduces the need for shared code, to ensure that common components are re-usable. However, at another level, we want not only to re-use components but also to re-use architecture. This means, setting up a standardized project architecture which relies on these standardized re-usable components.

Customer projects always higher priority, then Joe came across the Optivem Framework.

<a name="what" />
### What is the Optivem Framework?



<a name="why" />
### Why should I use the Optivem Framework?

As teams and projects grow over time, a common situation that occurs is that code has to be copy pasted between projects. Examples include:
* When creating a new project, frequently the structure is based on the structure of previous projects, e.g. for every new project, developers need to setup Repository, Service, Web projects.
* There are some common utilities that may be needed between projects, e.g. utility methods for working with text, working with files, working with dates, etc.
* Other common elements, such as base repository classes, logging, validation may also be copied because it's needed across many projects

Welcome to the Optivem Framework for .NET Core 2.2, which is designed to solve the problems above:
1. At the lower level, it provides re-usable components
2. At the higher level, it provides guidelines for project architecture
3. Enables you to focus on your projects and products, deliver features faster to customers with high quality




<a name="getting-started" />
## Getting Started

<a name="installation" />
### Installation 

<a name="first-project" />
### Create your first project 

<a name="sample-projects" />
### Real-life sample projects




<a name="technical-reference" />
## Technical Reference

<a name="architecture" />
### Architecture

The Optivem Framework is founded upon Clean Architecture principles and supports:
* Modularity & re-usability
* Extensibility & flexibility
* Maintainability & testibility
* Scalability and portability

The Optivem Framework consists of the following:
* Core (contains the Application Layer and the Domain Layer implementations)
* Infrastructure (contains implementation of infrastructure to support the Core)
* Web (contains the web presentation layer)
* Test (contains base classes for testing)

NuGet packages are split by the architectural layer:
* [Core Packages](#core-packages)
* [Infrastructure Packages](#infrastructure-packages)
* [Web Packages](#web-packages)
* [Test Packages](#test-packages)

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

<a name="further-information" />
## Further Information

<a name="support" />
### Getting support

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/framework-dotnetcore/issues](https://github.com/optivem/framework-dotnetcore/issues).

<a name="license" />
### MIT License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.