#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["template/microservice/src/Web/Atomiv.Template.Web.RestApi/Atomiv.Template.Web.RestApi.csproj", "template/microservice/src/Web/Atomiv.Template.Web.RestApi/"]
COPY ["template/microservice/src/DependencyInjection/Atomiv.Template.DependencyInjection/Atomiv.Template.DependencyInjection.csproj", "template/microservice/src/DependencyInjection/Atomiv.Template.DependencyInjection/"]
COPY ["src/DependencyInjection/Core/Application/Atomiv.DependencyInjection.Core.Application.csproj", "src/DependencyInjection/Core/Application/"]
COPY ["src/Core/Application/Atomiv.Core.Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Atomiv.Core.Domain.csproj", "src/Core/Domain/"]
COPY ["src/Core/Application.Interface/Atomiv.Core.Application.Interface.csproj", "src/Core/Application.Interface/"]
COPY ["src/DependencyInjection/Base/DependencyInjection/Atomiv.DependencyInjection.Common.csproj", "src/DependencyInjection/Base/DependencyInjection/"]
COPY ["src/DependencyInjection/Infrastructure/AspNetCore/Atomiv.DependencyInjection.Infrastructure.AspNetCore.csproj", "src/DependencyInjection/Infrastructure/AspNetCore/"]
COPY ["src/Infrastructure/AspNetCore/Atomiv.Infrastructure.AspNetCore.csproj", "src/Infrastructure/AspNetCore/"]
COPY ["src/Core/All/Atomiv.Core.All.csproj", "src/Core/All/"]
COPY ["src/Core/Common/Atomiv.Core.Common.csproj", "src/Core/Common/"]
COPY ["src/Infrastructure/System/Atomiv.Infrastructure.System.csproj", "src/Infrastructure/System/"]
COPY ["src/DependencyInjection/Infrastructure/System/Atomiv.DependencyInjection.Infrastructure.System.csproj", "src/DependencyInjection/Infrastructure/System/"]
COPY ["template/microservice/src/Tools/Atomiv.Template.Tools.Migrator/Atomiv.Template.Tools.Migrator.csproj", "template/microservice/src/Tools/Atomiv.Template.Tools.Migrator/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Persistence/Atomiv.Template.Infrastructure.Domain.Persistence.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Persistence/"]
COPY ["src/Infrastructure/EntityFrameworkCore/Atomiv.Infrastructure.EntityFrameworkCore.csproj", "src/Infrastructure/EntityFrameworkCore/"]
COPY ["src/Infrastructure/SequentialGuid/Atomiv.Infrastructure.SequentialGuid.csproj", "src/Infrastructure/SequentialGuid/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.All/Atomiv.Template.Core.All.csproj", "template/microservice/src/Core/Atomiv.Template.Core.All/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Application/Atomiv.Template.Core.Application.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Application/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Common/Atomiv.Template.Core.Common.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Common/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Application.Commands/Atomiv.Template.Core.Application.Commands.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Application.Commands/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Domain/Atomiv.Template.Core.Domain.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Domain/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Application.Queries/Atomiv.Template.Core.Application.Queries.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Application.Queries/"]
COPY ["template/microservice/src/Core/Atomiv.Template.Core.Application.Commands.Handlers/Atomiv.Template.Core.Application.Commands.Handlers.csproj", "template/microservice/src/Core/Atomiv.Template.Core.Application.Commands.Handlers/"]
COPY ["src/DependencyInjection/Infrastructure/EntityFrameworkCore/Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore.csproj", "src/DependencyInjection/Infrastructure/EntityFrameworkCore/"]
COPY ["src/DependencyInjection/Infrastructure/AutoMapper/Atomiv.DependencyInjection.Infrastructure.AutoMapper.csproj", "src/DependencyInjection/Infrastructure/AutoMapper/"]
COPY ["src/Infrastructure/AutoMapper/Atomiv.Infrastructure.AutoMapper.csproj", "src/Infrastructure/AutoMapper/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.All/Atomiv.Template.Infrastructure.All.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.All/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb/Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb/"]
COPY ["src/Infrastructure/MongoDb/Atomiv.Infrastructure.MongoDb.csproj", "src/Infrastructure/MongoDb/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb/Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Validation/Atomiv.Template.Infrastructure.Commands.Validation.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Validation/"]
COPY ["src/Infrastructure/FluentValidation/Atomiv.Infrastructure.FluentValidation.csproj", "src/Infrastructure/FluentValidation/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Authorization/Atomiv.Template.Infrastructure.Commands.Authorization.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Authorization/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Authorization/Atomiv.Template.Infrastructure.Queries.Authorization.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Authorization/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Web.Authentication/Atomiv.Template.Infrastructure.Web.Authentication.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Web.Authentication/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Repositories/Atomiv.Template.Infrastructure.Domain.Repositories.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Repositories/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Services/Atomiv.Template.Infrastructure.Domain.Services.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Services/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Mapping/Atomiv.Template.Infrastructure.Commands.Mapping.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Commands.Mapping/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Validation/Atomiv.Template.Infrastructure.Queries.Validation.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Validation/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb/Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Identities.MongoDb/Atomiv.Template.Infrastructure.Domain.Identities.MongoDb.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Identities.MongoDb/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Identities/Atomiv.Template.Infrastructure.Domain.Identities.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Domain.Identities/"]
COPY ["template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Handlers/Atomiv.Template.Infrastructure.Queries.Handlers.csproj", "template/microservice/src/Infrastructure/Atomiv.Template.Infrastructure.Queries.Handlers/"]
COPY ["src/DependencyInjection/Infrastructure/FluentValidation/Atomiv.DependencyInjection.Infrastructure.FluentValidation.csproj", "src/DependencyInjection/Infrastructure/FluentValidation/"]
COPY ["src/DependencyInjection/Core/Domain/Atomiv.DependencyInjection.Core.Domain.csproj", "src/DependencyInjection/Core/Domain/"]
COPY ["src/DependencyInjection/Infrastructure/MediatR/Atomiv.DependencyInjection.Infrastructure.MediatR.csproj", "src/DependencyInjection/Infrastructure/MediatR/"]
COPY ["src/Infrastructure/MediatR/Atomiv.Infrastructure.MediatR.csproj", "src/Infrastructure/MediatR/"]
COPY ["src/DependencyInjection/Infrastructure/NewtonsoftJson/Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson.csproj", "src/DependencyInjection/Infrastructure/NewtonsoftJson/"]
COPY ["src/Infrastructure/NewtonsoftJson/Atomiv.Infrastructure.NewtonsoftJson.csproj", "src/Infrastructure/NewtonsoftJson/"]
COPY ["src/Web/AspNetCore/Atomiv.Web.AspNetCore.csproj", "src/Web/AspNetCore/"]
COPY ["src/DependencyInjection/Web/AspNetCore/Atomiv.DependencyInjection.Web.AspNetCore.csproj", "src/DependencyInjection/Web/AspNetCore/"]
RUN dotnet restore "template/microservice/src/Web/Atomiv.Template.Web.RestApi/Atomiv.Template.Web.RestApi.csproj"
COPY . .
WORKDIR "/src/template/microservice/src/Web/Atomiv.Template.Web.RestApi"
RUN dotnet build "Atomiv.Template.Web.RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Atomiv.Template.Web.RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Atomiv.Template.Web.RestApi.dll"]