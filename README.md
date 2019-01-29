## Introduction

[![Build Status](https://img.shields.io/appveyor/ci/optivem/platform-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/platform-dotnetcore)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

## Website

The main website for this project on GitHub: [opensource.optivem.com/platform-dotnetcore](https://opensource.optivem.com/platform-dotnetcore).

### Architecture

Each library is split into:
* Interfaces
* Abstract base classes
* Concrete implementations

This enables your software development team to appropriately choose to depend on interfaces and within IoC container to configure implementations and execute unit testing. Furthermore, it also enables development teams to either choose to use the default provided implementations or develop custom implementations.

## Optivem Libraries

### Optivem .NET Core 2 Libraries

Libraries for application core for business logic and data abstraction:

| Interfaces | Implementations |
| ------------- | ------------- |
| Entity | Entity.Default |
| Repository | Repository.EntityFramework <br> Repository.Dapper <br> Repository.AdoNet <br> Repository.MongoDb <br> Repository.Cassandra |
| UnitOfWork | UnitOfWork.EntityFramework <br> UnitOfWork.Dapper <br> UnitOfWork.AdoNet <br> UnitOfWork.MongoDb <br> UnitOfWork.Cassandra |
| Service | Service.Default |
| Controller | Controller.Default |

Infrastructure libraries for cross-cutting concerns:

| Interface | Implementations |
| ------------- | ------------- |
| Parsing | Parsing.Default |
| Mapping | Mapping.Default |
| Validation | Validation.Default |
| Serialization | Serialization.Json <br> Serialization.Xml <br> Serialization.Csv <br> Serialization.Excel |
| Logging | Logging.Log4Net <br> Logging.NLog |
| Messaging | TBD |
| Identity | Identity.AspNetIdentity |
| Authentication | Authentication.OAuth  |
| Authorization | Authorization.OAuth  |
| Workflow | TBD  |
| Queue | TBD  |
| Process | Process.Default <br> Process.Remote  |
| Notification | Notification.SignalR <br> Notification.Email |
| Configuration | Configuration.Default  |

Infrastructure libraries for integration with external systems:

| Interface | Implementations |
| ------------- | ------------- |
| Clock | Clock.Default |
| FileSystem | FileSystem.Default <br> FileSystem.Ftp |
| Email | Email.Gmail <br> Email.Outlook <br> Email.SendGrid |
| Cloud | Cloud.Azure <br> Cloud.Aws <br> Email.Google |
| RestClient | RestClient.RestSharp |
| RestService | RestService.AspNetCore |
| SoapClient | TBD |
| SoapService | TBD |

<!-- TODO: VC: Check regarding PDF and also DSV, additionally UOW and also design patterns, e.g. factory and builder... azure.. amazon... configuration, testing, sql lite, NHibernate, DDD, CQRS, Domain... IoC -> AutoFac, Ninject, Unity, Kafka  -->


<!-- TODO: VC: Search infrastructure https://www.nuget.org/packages?page=8&q=infrastructure -->



## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/platform-dotnetcore/issues](https://github.com/optivem/platform-dotnetcore/issues).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.