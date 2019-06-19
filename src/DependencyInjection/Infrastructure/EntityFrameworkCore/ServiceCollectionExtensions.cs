using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Domain;
using Optivem.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection.Infrastructure.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkCoreInfrastructure<TDbContext, TUnitOfWork>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null, params Assembly[] assemblies)
            where TDbContext : DbContext
            where TUnitOfWork : UnitOfWork<TDbContext>
        {
            services.AddDbContext<TDbContext>(optionsAction);
            services.AddScoped<IUnitOfWork, TUnitOfWork>();

            return services;
        }
    }
}
