using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Atomiv.DependencyInjection.Core.Application;
using Atomiv.DependencyInjection.Core.Domain;
using Atomiv.DependencyInjection.Infrastructure.AspNetCore;
using Atomiv.DependencyInjection.Infrastructure.AutoMapper;
using Atomiv.DependencyInjection.Infrastructure.FluentValidation;
using Atomiv.DependencyInjection.Infrastructure.MediatR;
using Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson;
using Atomiv.DependencyInjection.Infrastructure.System;
using Atomiv.Template.Infrastructure.Web.Authentication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Atomiv.Template.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var moduleTypes = GetModuleTypes();
            var assemblies = moduleTypes.Select(e => e.Assembly).ToArray();

            AddCoreModules<RequestType>(services, assemblies);
            AddInfrastructureModules(services, configuration, assemblies);
        }

        private static List<Type> GetModuleTypes()
        {
            var coreModuleTypes = new List<Type>
            {
                typeof(Core.Application.Module),
                typeof(Core.Application.Commands.Module),
                typeof(Core.Application.Commands.Handlers.Module),
                typeof(Core.Domain.Module),
                typeof(Core.Application.Queries.Module),
            };

            var infrastructureModuleTypes = new List<Type>
            {
                typeof(Infrastructure.Commands.Authorization.Module),
                typeof(Infrastructure.Commands.Mapping.Module),
                typeof(Infrastructure.Commands.Validation.Module),
                typeof(Infrastructure.Domain.Identities.Module),
                typeof(Infrastructure.Domain.Services.Module),
                typeof(Infrastructure.Queries.Authorization.Module),
                typeof(Infrastructure.Queries.Validation.Module),
                typeof(Infrastructure.Web.Authentication.Module),
            };

            infrastructureModuleTypes.AddRange(GetEfCoreInfrastructureModules());
            // infrastructureModuleTypes.AddRange(GetMongoDBInfrastructureModules());

            var moduleTypes = new List<Type>();
            moduleTypes.AddRange(coreModuleTypes);
            moduleTypes.AddRange(infrastructureModuleTypes);

            return moduleTypes;
        }

        private static List<Type> GetEfCoreInfrastructureModules()
        {
            return new List<Type>
            {
                typeof(Infrastructure.Domain.Persistence.Module),
                typeof(Infrastructure.Domain.Repositories.Module),
                typeof(Infrastructure.Queries.Handlers.Module),
            };
        }

        private static List<Type> GetMongoDBInfrastructureModules()
        {
            return new List<Type>
            {
                typeof(Infrastructure.Domain.Persistence.MongoDB.Module),
                typeof(Infrastructure.Domain.Repositories.MongoDB.Module),
                typeof(Infrastructure.Queries.Handlers.MongoDB.Module),
            };
        }

        private static void AddCoreModules<TRequestType>(this IServiceCollection services, Assembly[] assemblies)
            where TRequestType : Enum
        {
            services.AddApplicationCore<TRequestType>(assemblies);
            services.AddDomainCore(assemblies);
        }

        private static void AddInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            services.AddApplicationUserContext<ApplicationUser, 
                RequestType, 
                ApplicationUserSerializer, 
                IApplicationUserContext,
                ApplicationUserContext>();

            services.AddAutoMapper(assemblies);
            services.AddMediatR(assemblies);

            services.AddAspNetCoreInfrastructure(assemblies);
            services.AddAutoMapperInfrastructure(assemblies);
            services.AddFluentValidationInfrastructure(assemblies);
            services.AddMediatRInfrastructure(assemblies);
            services.AddNewtonsoftJsonInfrastructure(assemblies);
            services.AddSystemInfrastructure(assemblies);

            services.AddEfCoreInfrastructureModules(configuration, assemblies);
            // services.AddMongoDBInfrastructureModules(configuration, assemblies);
        }

        private static void AddEfCoreInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);

            var type = typeof(Tools.Migrator.Module);
            var assembly = type.Assembly;
            var assemblyName = assembly.FullName;

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connection, e =>
                {
                    e.MigrationsAssembly(assemblyName);
                });

                options.EnableSensitiveDataLogging();
            });

            services.AddEntityFrameworkCoreInfrastructure(assemblies);
        }

        private static void AddMongoDBInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            var dbSettingsSection = configuration.GetSection(nameof(DbSettings));

            services.Configure<IDbSettings>(dbSettingsSection);

            services.AddSingleton<IDbSettings>(e =>
                e.GetRequiredService<IOptions<DbSettings>>().Value);

            services.AddSingleton<MongoDBContext>();
        }
    }
}