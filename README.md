## Introduction

[![Build Status](https://img.shields.io/appveyor/ci/optivem/platform-dotnetcore.svg)](https://ci.appveyor.com/project/optivem/platform-dotnetcore)
[![MIT License](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

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

## Documentation

Read the [documentation](docs/index.md).

## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/platform-dotnetcore/issues](https://github.com/optivem/platform-dotnetcore/issues).

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). This means you're free to use it for commercial and non-commercial purposes.

## Copyright

Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved.