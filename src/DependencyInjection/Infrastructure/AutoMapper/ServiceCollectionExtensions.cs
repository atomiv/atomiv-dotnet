using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Infrastructure.AutoMapper;
using System;
using System.Collections;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        private static Type EnumerableType = typeof(IEnumerable);

        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            services.AddScoped<IUseCaseMapper, UseCaseMapper>();

            return services;
        }
    }
}
