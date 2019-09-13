using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.AutoMapper;
using System;
using System.Collections;
using System.Reflection;
using IMapper = Optivem.Framework.Core.Common.Mapping.IMapper;

namespace Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        private static Type EnumerableType = typeof(IEnumerable);

        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            services.AddScoped<IMapper, UseCaseMapper>();

            return services;
        }
    }
}
