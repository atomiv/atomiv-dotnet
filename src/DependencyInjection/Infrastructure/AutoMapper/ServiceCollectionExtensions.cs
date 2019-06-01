using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            services.AddScoped<IRequestMapper, RequestMapper>();
            services.AddScoped<IResponseMapper, ResponseMapper>();

            return services;
        }
    }
}
