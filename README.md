## Introduction

[![Build Status](https://img.shields.io/appveyor/ci/optivem/platform-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/platform-dotnetcore)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

Welcome to the Optivem Platform (.NET Core 2.2). The Optivem Platform is founded upon Clean Architecture principles and supports:
* Modularity & re-usability
* Extensibility & flexibility
* Maintainability & testibility
* Scalability and portability

## Architecture

The Optivem Platform consists of the following:
* Core (contains the Application Layer and the Domain Layer implementations)
* Infrastructure (contains implementation of infrastructure to support the Core)
* Web (contains the web presentation layer)
* Test (contains base classes for testing)


## Core

Optivem.Platform.Core.Common.Common:

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

Optivem.Platform.Core.Domain:

* Optivem.Platform.Core.Domain.All
* Optivem.Platform.Core.Domain.Entity
* Optivem.Platform.Core.Domain.Entity.Default
* Optivem.Platform.Core.Domain.Repository
* Optivem.Platform.Core.Domain.Service
* Optivem.Platform.Core.Domain.Service.Default

Optivem.Platform.Core.Application:

* Optivem.Platform.Core.Application.All
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Application.Service.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Application.Service) Optivem.Platform.Core.Application.Service
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Application.Service.Default.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Application.Service.Default) Optivem.Platform.Core.Application.Service.Default

## Infrastructure

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
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.Json.NewtonsoftJson.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.Json.NewtonsoftJson) Optivem.Platform.Infrastructure.Common.Json.NewtonsoftJson
* Optivem.Platform.Infrastructure.Common.Serialization.Xml
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium) Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium


<!-- TODO: VC: TEMP -->
<!-- * [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Infrastructure.Common.XYZ.svg)](https://www.nuget.org/packages/Optivem.Platform.Infrastructure.Common.XYZ) Optivem.Platform.Infrastructure.Common.XYZ -->


Optivem.Platform.Infrastructure.Domain:
* Optivem.Platform.Infrastructure.Domain.Repository.EntityFrameworkCore

## Web

Optivem.Platform.Web.AspNetCore:
* Optivem.Platform.Web.AspNetCore.Common
* Optivem.Platform.Web.AspNetCore.Mvc
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Web.AspNetCore.Rest.svg)](https://www.nuget.org/packages/Optivem.Platform.Web.AspNetCore.Rest) Optivem.Platform.Web.AspNetCore.Rest
* Optivem.Platform.Web.AspNetCore.Soap

## Test

* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Test.Xunit.Common.svg)](https://www.nuget.org/packages/Optivem.Platform.Test.Xunit.Common) Optivem.Platform.Test.Xunit.Common
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Test.Xunit.Web.AspNetCore.svg)](https://www.nuget.org/packages/Optivem.Platform.Test.Xunit.Web.AspNetCore) Optivem.Platform.Test.Xunit.Web.AspNetCore
* Optivem.Platform.Test.Web.Selenium

## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/platform-dotnetcore/issues](https://github.com/optivem/platform-dotnetcore/issues).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). 

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.