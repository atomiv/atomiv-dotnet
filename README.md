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




Optivem.Platform.Web.AspNetCore.Rest





## Optivem.Platform.Core

Optivem.Platform.Core.Common.Common:

* Optivem.Platform.Core.Common.All
* Optivem.Platform.Core.Common.Clock
* Optivem.Platform.Core.Common.Email
* Optivem.Platform.Core.Common.FileSystem
* Optivem.Platform.Core.Common.Logging
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Mapping.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Mapping) Optivem.Platform.Core.Common.Mapping
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Parsing.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Parsing) Optivem.Platform.Core.Common.Parsing
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Platform.Core.Common.Repository.svg)](https://www.nuget.org/packages/Optivem.Platform.Core.Common.Repository) Optivem.Platform.Core.Common.Repository
* Optivem.Platform.Core.Common.Serialization

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

## Optivem.Platform.Infrastructure

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
* Optivem.Platform.Infrastructure.Common.Serialization.Csv
* Optivem.Platform.Infrastructure.Common.Serialization.Dsv
* Optivem.Platform.Infrastructure.Common.Serialization.Excel
* Optivem.Platform.Infrastructure.Common.Serialization.FixedWidth
* Optivem.Platform.Infrastructure.Common.Serialization.Json
* Optivem.Platform.Infrastructure.Common.Serialization.Xml

Optivem.Platform.Infrastructure.Domain:
* Optivem.Platform.Infrastructure.Domain.Repository.EntityFrameworkCore

## Optivem.Platform.Web

Optivem.Platform.Web.AspNetCore:
* Optivem.Plaform.Web.AspNetCore.Common
* Optivem.Plaform.Web.AspNetCore.Mvc
* [![NuGet](https://img.shields.io/nuget/v/Optivem.Plaform.Web.AspNetCore.Rest.svg)](https://www.nuget.org/packages/Optivem.Plaform.Web.AspNetCore.Rest) Optivem.Plaform.Web.AspNetCore.Rest
* Optivem.Plaform.Web.AspNetCore.Soap

## Optivem.Platform.Test

* Optivem.Platform.Test.Unit
* Optivem.Platform.Test.Integration

## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/platform-dotnetcore/issues](https://github.com/optivem/platform-dotnetcore/issues).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). 

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.