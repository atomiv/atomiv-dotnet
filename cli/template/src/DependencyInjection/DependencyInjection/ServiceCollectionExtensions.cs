using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.DependencyInjection.Core.Application;
using Atomiv.DependencyInjection.Core.Domain;
using Atomiv.DependencyInjection.Infrastructure.AutoMapper;
using Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Atomiv.DependencyInjection.Infrastructure.FluentValidation;
using Atomiv.DependencyInjection.Infrastructure.MediatR;
using Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson;
using Cli.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Cli.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var coreModules = new List<Type>
            {
                typeof(Core.Application.Module),
                typeof(Core.Domain.Module),
            };

            var infrastructureModules = new List<Type>
            {
                typeof(Infrastructure.AutoMapper.Module),
                typeof(Infrastructure.EntityFrameworkCore.Module),
                typeof(Infrastructure.FluentValidation.Module),
                typeof(Infrastructure.MediatR.Module),
            };

            var modules = new List<Type>();
            modules.AddRange(coreModules);
            modules.AddRange(infrastructureModules);

            var assemblies = modules.Select(e => e.Assembly).ToArray();

            // Core
            services.AddApplicationCore(assemblies);
            services.AddDomainCore(assemblies);

            // Infrastructure
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);
            services.AddEntityFrameworkCoreInfrastructure<DatabaseContext>(options => options.UseSqlServer(connection), assemblies);
            services.AddAutoMapperInfrastructure(assemblies);
            services.AddFluentValidationInfrastructure(assemblies);
            services.AddMediatRInfrastructure(assemblies);
            services.AddNewtonsoftJsonInfrastructure(assemblies);
        }
    }
}
