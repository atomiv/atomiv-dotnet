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

Common:

* Optivem.Framework.Core.Common.All
* Optivem.Framework.Core.Common.Clock
* Optivem.Framework.Core.Common.Email
* Optivem.Framework.Core.Common.FileSystem
* Optivem.Framework.Core.Common.Logging
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.Mapping.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.Mapping) Optivem.Framework.Core.Common.Mapping
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.Parsing.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.Parsing) Optivem.Framework.Core.Common.Parsing
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.Repository.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.Repository) Optivem.Framework.Core.Common.Repository
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.RestClient.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.RestClient) Optivem.Framework.Core.Common.RestClient
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.Serialization.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.Serialization) Optivem.Framework.Core.Common.Serialization
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Common.WebAutomation.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Common.WebAutomation) Optivem.Framework.Core.Common.WebAutomation

Domain:

* Optivem.Framework.Core.Domain.All
* Optivem.Framework.Core.Domain.Entity
* Optivem.Framework.Core.Domain.Entity.Default
* Optivem.Framework.Core.Domain.Repository
* Optivem.Framework.Core.Domain.Service
* Optivem.Framework.Core.Domain.Service.Default

Application:

* Optivem.Framework.Core.Application.All
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Application.Service.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Application.Service) Optivem.Framework.Core.Application.Service
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Core.Application.Service.Default.svg)](https://www.nuget.org/packages/Optivem.Framework.Core.Application.Service.Default) Optivem.Framework.Core.Application.Service.Default

<a name="infrastructure-packages" />
### Infrastructure Packages

Optivem.Framework.Infrastructure.Common:

* Optivem.Framework.Infrastructure.Common.All
* Optivem.Framework.Infrastructure.Common.Clock.Default
* Optivem.Framework.Infrastructure.Common.Email.Gmail
* Optivem.Framework.Infrastructure.Common.Email.MicrosoftExchange
* Optivem.Framework.Infrastructure.Common.FileSystem.Default
* Optivem.Framework.Infrastructure.Common.Logging.Log4net
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper) Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Parsing.Default.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Parsing.Default) Optivem.Framework.Infrastructure.Common.Parsing.Default
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Repository.EntityFrameworkCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Repository.EntityFrameworkCore) Optivem.Framework.Infrastructure.Common.Repository.EntityFrameworkCore
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.RestClient.Default.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.RestClient.Default) Optivem.Framework.Infrastructure.Common.RestClient.Default
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Serialization.Csv.CsvHelper.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Serialization.Csv.CsvHelper) Optivem.Framework.Infrastructure.Common.Serialization.Csv.CsvHelper
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Serialization.Default.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Serialization.Default) Optivem.Framework.Infrastructure.Common.Serialization.Default
* Optivem.Framework.Infrastructure.Common.Serialization.Dsv
* Optivem.Framework.Infrastructure.Common.Serialization.Excel
* Optivem.Framework.Infrastructure.Common.Serialization.FixedWidth
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.Serialization.Json.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.Serialization.Json.NewtonsoftJson) Optivem.Framework.Infrastructure.Common.Serialization.Json.NewtonsoftJson
* Optivem.Framework.Infrastructure.Common.Serialization.Xml
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium) Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium


<!-- TODO: VC: TEMP -->
<!-- * [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Infrastructure.Common.XYZ.svg)](https://www.nuget.org/packages/Optivem.Framework.Infrastructure.Common.XYZ) Optivem.Framework.Infrastructure.Common.XYZ -->


Optivem.Framework.Infrastructure.Domain:
* Optivem.Framework.Infrastructure.Domain.Repository.EntityFrameworkCore

<a name="web-packages" />
### Web Packages

Optivem.Framework.Web.AspNetCore:
* Optivem.Framework.Web.AspNetCore.Common
* Optivem.Framework.Web.AspNetCore.Mvc
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Web.AspNetCore.Rest.svg)](https://www.nuget.org/packages/Optivem.Framework.Web.AspNetCore.Rest) Optivem.Framework.Web.AspNetCore.Rest
* Optivem.Framework.Web.AspNetCore.Soap

<a name="test-packages" />
### Test Packages

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.Xunit.Common.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.Xunit.Common) Optivem.Framework.Test.Xunit.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Framework.Test.Xunit.Web.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Framework.Test.Xunit.Web.AspNetCore) Optivem.Framework.Test.Xunit.Web.AspNetCore
* Optivem.Framework.Test.Xunit.Web.Selenium



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