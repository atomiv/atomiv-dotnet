using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.AutoMapper;
using System.Reflection;

namespace Optivem.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            assemblies = assemblies.GetCheckedAssemblies(AssemblyNameSuffixes.Infrastructure.AutoMapper);

            services.AddAutoMapper(assemblies);
            services.AddScoped<IRequestMapper, RequestMapper>();
            services.AddScoped<IResponseMapper, ResponseMapper>();

            return services;
        }
    }
}
