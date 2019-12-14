using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;
using Optivem.Framework.Core.Common.Time;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.DependencyInjection.Core.Application;
using Optivem.Framework.DependencyInjection.Core.Domain;
using Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.Framework.DependencyInjection.Infrastructure.MediatR;
using Optivem.Framework.DependencyInjection.Infrastructure.NewtonsoftJson;
using Optivem.Framework.DependencyInjection.Infrastructure.System;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Optivem.Template.DependencyInjection
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
                typeof(Infrastructure.AutoMapper.Module),
                typeof(Infrastructure.EntityFrameworkCore.Module),
                typeof(Infrastructure.FluentValidation.Module),
                typeof(Infrastructure.MediatR.Module),
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

            // TODO: VC: This should be in framework
            services.AddScoped<IIdentityGenerator<CustomerIdentity>, CustomerIdentityGenerator>();
            services.AddScoped<IIdentityGenerator<OrderIdentity>, OrderIdentityGenerator>();
            services.AddScoped<IIdentityGenerator<OrderItemIdentity>, OrderItemIdentityGenerator>();
            services.AddScoped<IIdentityGenerator<ProductIdentity>, ProductIdentityGenerator>();

            // TODO: VC: This should be in framework
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<IOrderFactory, OrderFactory>();
            services.AddScoped<IProductFactory, ProductFactory>();
        }

        private static void AddInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
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