using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.DependencyInjection.Common;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        private static Type UnitOfWorkType = typeof(IUnitOfWork);
        private static Type AddAggregateRootMapperType = typeof(IAddAggregateRootMapper<,>);
        private static Type RemoveAggregateRootMapperType = typeof(IRemoveAggregateRootMapper<,>);
        private static Type GetAggregateRootMapperType = typeof(IGetAggregateRootMapper<,>);

        public static IServiceCollection AddEntityFrameworkCoreInfrastructure<TDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null, params Assembly[] assemblies)
            where TDbContext : DbContext
        {
            var types = assemblies.GetTypes();

            services.AddDbContext<TDbContext>(optionsAction);
            services.AddUnitOfWork(types);
            services.AddMappers(types);

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationType = types.GetConcreteImplementationsOfInterface(UnitOfWorkType).Single();
            services.AddScoped(UnitOfWorkType, implementationType);

            return services;
        }

        private static IServiceCollection AddMappers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var addAggregateRootImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(AddAggregateRootMapperType);
            var removeAggregateRootImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(RemoveAggregateRootMapperType);
            var getAggregateRootImplementationTypes = types.GetConcreteImplementationsOfGenericInterface(GetAggregateRootMapperType);

            services.AddScopedOpenType(AddAggregateRootMapperType, addAggregateRootImplementationTypes);
            services.AddScopedOpenType(RemoveAggregateRootMapperType, removeAggregateRootImplementationTypes);
            services.AddScopedOpenType(GetAggregateRootMapperType, getAggregateRootImplementationTypes);

            return services;
        }
    }
}
