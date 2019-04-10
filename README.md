## Optivem Platform

[![Build Status](https://img.shields.io/appveyor/ci/optivem/platform-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/platform-dotnetcore)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

Welcome to the Optivem Platform! The Optivem Platform was created to help you increase code quality, help you deliver products faster to customers and reduce your overall software development cost. This documentation page will show you how to get up-and-running with the Optivem Platform in your .NET Core 2.2 software projects. 

## Table of Contents

* [Introduction](#introduction) describes the problems faced by software teams as the number of projects and codebase grows and the solution to that problem through development of standardized architecture and re-usable components through the Optivem Platform
* [Architecture](#architecture) describes the overall architectural approach behind the Optivem Platform, focusing on Clean Architecture principles and layers
* [Packages](#packages) describes the overall architectural approach behind the Optivem Platform, focusing on Clean Architecture principles and layers, including:
** [Core Packages](#core-packages)
** [Infrastructure Packages](#infrastructure-packages)
** [Web Packages](#web-packages)
** [Test Packages](#test-packages)
* [Issues](#issues) provides instructions for reporting any issues or submitting ideas for development
* [Licence](#licence) provides licence details - MIT licence

<a name="introduction" />
## Introduction

As teams and projects grow over time, a common situation that occurs is that code has to be copy pasted between projects. Examples include:
* When creating a new project, frequently the structure is based on the structure of previous projects, e.g. for every new project, developers need to setup Repository, Service, Web projects.
* There are some common utilities that may be needed between projects, e.g. utility methods for working with text, working with files, working with dates, etc.
* Other common elements, such as base repository classes, logging, validation may also be copied because it's needed across many projects

At first, copy-paste is fine - it is faster in the short run. For example, let's say we started with some utility class for parsing text files. At first, it was all "simple", it was just reading a set of lines from the text file. This was developed in Project A. Then, Project B came along, where there was also the requirement for reading text files, so naturally the developer in Project B copied the code base from Project A. However, due to different requirements, parsing text files in Project B was a bit more complex, needed to handle different date formats depending on location settings, so the developer had to adapt the code. Then Project C came up, and there was also a requirement for reading from text files, but with the additional requirement that headers needed to be adjusted. Then a bug was found affecting base parsing functionality, and so then in all the projects A, B, C developers had to manually fix the bug. Afterwards, Project D came up and it had some requirements like Project A and some requirements like Project C, so then the developer copied some parts from Project A, some parts from Project C, and combined it together. Furthermore, some newcomers joined the team and when they had to implement text parsing, the other team members told them what was implemented on one project, was was on another, so the developers often had to search through multiple projects.

Now we see that, as the number of project grows and as the codebase grows, that the copy-paste solution is not really maintainable. Reasons are because when creating new projects, develoeprs have to search for older projects to copy the code from, and when bugs are found, it needs to be solved multiple times. This increases overall development cost, introduces risk and decreases quality. So with this in mind, it introduces the need for shared code, to ensure that common components are re-usable. However, at another level, we want not only to re-use components but also to re-use architecture. This means, setting up a standardized project architecture which relies on these standardized re-usable components.

Welcome to the Optivem Platform for .NET Core 2.2, which is designed to solve the problems above:
1. At the lower level, it provides re-usable components
2. At the higher level, it provides guidelines for project architecture
3. Enables you to focus on your projects and products, deliver features faster to customers with high quality

<a name="architecture" />
## Architecture

The Optivem Platform is founded upon Clean Architecture principles and supports:
* Modularity & re-usability
* Extensibility & flexibility
* Maintainability & testibility
* Scalability and portability

The Optivem Platform consists of the following:
* Core (contains the Application Layer and the Domain Layer implementations)
* Infrastructure (contains implementation of infrastructure to support the Core)
* Web (contains the web presentation layer)
* Test (contains base classes for testing)

<a name="packages" />
## Packages

NuGet packages are split by the architectural layer:
* [Core Packages](#core-packages)
* [Infrastructure Packages](#infrastructure-packages)
* [Web Packages](#web-packages)
* [Test Packages](#test-packages)

<a name="core-packages" />
### Core Packages

Common:

* Optivem.Platform.Core.Common.All
* Optivem.Platform.Core.Common.Clock
* Optivem.Platform.Core.Common.Email
* Optivem.Platform.Core.Common.FileSystem
* Optivem.Platform.Core.Common.Logging
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Mapping.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Mapping) Optivem.Platform.Core.Common.Mapping
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Parsing.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Parsing) Optivem.Platform.Core.Common.Parsing
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Repository.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Repository) Optivem.Platform.Core.Common.Repository
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.RestClient.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.RestClient) Optivem.Platform.Core.Common.RestClient
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Serialization.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Serialization) Optivem.Platform.Core.Common.Serialization
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.WebAutomation.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.WebAutomation) Optivem.Platform.Core.Common.WebAutomation

Domain:

* Optivem.Platform.Core.Domain.All
* Optivem.Platform.Core.Domain.Entity
* Optivem.Platform.Core.Domain.Entity.Default
* Optivem.Platform.Core.Domain.Repository
* Optivem.Platform.Core.Domain.Service
* Optivem.Platform.Core.Domain.Service.Default

Application:

* Optivem.Platform.Core.Application.All
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Application.Service.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Application.Service) Optivem.Platform.Core.Application.Service
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Application.Service.Default.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Application.Service.Default) Optivem.Platform.Core.Application.Service.Default

<a name="infrastructure-packages" />
### Infrastructure Packages

Optivem.Platform.Infrastructure.Common:

* Optivem.Platform.Infrastructure.Common.All
* Optivem.Platform.Infrastructure.Common.Clock.Default
* Optivem.Platform.Infrastructure.Common.Email.Gmail
* Optivem.Platform.Infrastructure.Common.Email.MicrosoftExchange
* Optivem.Platform.Infrastructure.Common.FileSystem.Default
* Optivem.Platform.Infrastructure.Common.Logging.Log4net
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper) Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Parsing.Default.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Parsing.Default) Optivem.Platform.Infrastructure.Common.Parsing.Default
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore) Optivem.Platform.Infrastructure.Common.Repository.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.RestClient.Default.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.RestClient.Default) Optivem.Platform.Infrastructure.Common.RestClient.Default
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper) Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Serialization.Default.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Serialization.Default) Optivem.Platform.Infrastructure.Common.Serialization.Default
* Optivem.Platform.Infrastructure.Common.Serialization.Dsv
* Optivem.Platform.Infrastructure.Common.Serialization.Excel
* Optivem.Platform.Infrastructure.Common.Serialization.FixedWidth
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson) Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson
* Optivem.Platform.Infrastructure.Common.Serialization.Xml
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium) Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium


<!-- TODO: VC: TEMP -->
<!-- * [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.XYZ.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.XYZ) Optivem.Platform.Infrastructure.Common.XYZ -->


Optivem.Platform.Infrastructure.Domain:
* Optivem.Platform.Infrastructure.Domain.Repository.EntityFrameworkCore

<a name="web-packages" />
### Web Packages

Optivem.Platform.Web.AspNetCore:
* Optivem.Platform.Web.AspNetCore.Common
* Optivem.Platform.Web.AspNetCore.Mvc
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Web.AspNetCore.Rest.svg)](https://www.nuget.org/packages/Optivem.Platform.Web.AspNetCore.Rest) Optivem.Platform.Web.AspNetCore.Rest
* Optivem.Platform.Web.AspNetCore.Soap

<a name="test-packages" />
### Test Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Test.Xunit.Common.svg)](https://www.nuget.org/packages/Optivem.Platform.Test.Xunit.Common) Optivem.Platform.Test.Xunit.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Test.Xunit.Web.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Platform.Test.Xunit.Web.AspNetCore) Optivem.Platform.Test.Xunit.Web.AspNetCore
* Optivem.Platform.Test.Xunit.Web.Selenium

## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/platform-dotnetcore/issues](https://github.com/optivem/platform-dotnetcore/issues).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.