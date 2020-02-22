using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.DependencyInjection.Core.Application;
using Optivem.Atomiv.DependencyInjection.Core.Domain;
using Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.Atomiv.DependencyInjection.Infrastructure.MediatR;
using Optivem.Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson;
using Optivem.Atomiv.DependencyInjection.Infrastructure.System;
using Optivem.Atomiv.Template.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Optivem.Atomiv.Template.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var moduleTypes = GetModuleTypes();
            var assemblies = moduleTypes.Select(e => e.Assembly).ToArray();

            AddCoreModules(services, assemblies);
            AddInfrastructureModules(services, configuration, assemblies);
        }

        private static List<Type> GetModuleTypes()
        {
            var coreModuleTypes = new List<Type>
            {
                typeof(Core.Application.Module),
                typeof(Core.Domain.Module),
            };

            var infrastructureModuleTypes = new List<Type>
            {
                typeof(Infrastructure.External.Module),
                typeof(Infrastructure.Mapping.Module),
                typeof(Infrastructure.Persistence.Module),
                typeof(Infrastructure.Validation.Module),
            };

            var moduleTypes = new List<Type>();
            moduleTypes.AddRange(coreModuleTypes);
            moduleTypes.AddRange(infrastructureModuleTypes);

            return moduleTypes;
        }

        private static void AddCoreModules(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddApplicationCore(assemblies);
            services.AddDomainCore(assemblies);
        }

        private static void AddInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connection);
                options.EnableSensitiveDataLogging();
            });
            
            services.AddAutoMapper(assemblies);
            services.AddMediatR(assemblies);

            services.AddEntityFrameworkCoreInfrastructure(assemblies);
            services.AddAutoMapperInfrastructure(assemblies);
            services.AddFluentValidationInfrastructure(assemblies);
            services.AddMediatRInfrastructure(assemblies);
            services.AddNewtonsoftJsonInfrastructure(assemblies);
            services.AddSystemInfrastructure(assemblies);
        }
    }
}