using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Domain;
using Optivem.Infrastructure.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Optivem.DependencyInjection.Infrastructure.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        // TODO: VC: Find unit of work from assembly, also try to find context?

        public static IServiceCollection AddEntityFrameworkCoreInfrastructure<TDbContext, TUnitOfWork>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null, params Assembly[] assemblies)
            where TDbContext : DbContext
            where TUnitOfWork : UnitOfWork<TDbContext>
        {
            assemblies = assemblies.GetCheckedAssemblies(AssemblyNameSuffixes.Infrastructure.EntityFrameworkCore);

            services.AddDbContext<TDbContext>(optionsAction);
            services.AddScoped<IUnitOfWork, TUnitOfWork>();

            return services;
        }
    }
}
