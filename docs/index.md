## Introduction

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

## NuGet Packages

NuGet packages are split by the architectural layer:
* [Core Packages](docs/core.md)
* [Infrastructure Packages](docs/infrastructure.md)
* [Web Packages](docs/web.md)
* [Test Packages](docs/test.md)