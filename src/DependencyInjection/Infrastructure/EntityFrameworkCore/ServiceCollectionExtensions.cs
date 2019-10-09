using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        private static Type UnitOfWorkType = typeof(IUnitOfWork);
        private static Type AggregateRootFactoryType = typeof(Optivem.Framework.Infrastructure.EntityFrameworkCore.IAggregateRootFactory<,>);

        public static IServiceCollection AddEntityFrameworkCoreInfrastructure<TDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null, params Assembly[] assemblies)
            where TDbContext : DbContext
        {
            var types = assemblies.GetTypes();

            services.AddDbContext<TDbContext>(optionsAction);
            services.AddUnitOfWork(types);
            services.AddAggregateRootFactories(types);

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationType = types.GetConcreteImplementationsOfInterface(UnitOfWorkType).Single();
            services.AddScoped(UnitOfWorkType, implementationType);

            return services;
        }

        private static IServiceCollection AddAggregateRootFactories(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(AggregateRootFactoryType);
            services.AddScopedOpenType(AggregateRootFactoryType, implementationTypes);

            return services;
        }
    }
}
