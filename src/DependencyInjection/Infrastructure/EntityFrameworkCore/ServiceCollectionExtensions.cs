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
        // TODO: VC: Find unit of work from assembly, also try to find context?

        private static Type UnitOfWorkType = typeof(IUnitOfWork);

        public static IServiceCollection AddEntityFrameworkCoreInfrastructure<TDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null, params Assembly[] assemblies)
            where TDbContext : DbContext
        {
            var types = assemblies.GetTypes();

            services.AddDbContext<TDbContext>(optionsAction);
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
