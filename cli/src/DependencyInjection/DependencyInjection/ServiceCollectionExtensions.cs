using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.DependencyInjection.Core.Application;
using Optivem.Framework.DependencyInjection.Core.Domain;
using Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.Framework.DependencyInjection.Infrastructure.MediatR;
using Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson;
using Optivem.Cli.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Optivem.Cli.DependencyInjection
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
