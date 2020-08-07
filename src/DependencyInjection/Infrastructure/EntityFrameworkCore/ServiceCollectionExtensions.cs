using Microsoft.Extensions.DependencyInjection;
using Atomiv.DependencyInjection.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Atomiv.Core.Application;

namespace Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        private static Type UnitOfWorkType = typeof(IUnitOfWork);

        public static IServiceCollection AddEntityFrameworkCoreInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.GetTypes();

            services.AddUnitOfWork(types);

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationType = types.GetConcreteImplementationsOfInterface(UnitOfWorkType).Single();
            services.AddScoped(UnitOfWorkType, implementationType);

            return services;
        }
    }
}