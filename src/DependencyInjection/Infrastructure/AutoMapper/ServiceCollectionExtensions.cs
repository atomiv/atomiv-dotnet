using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mapster;
using MapsterMapper;
using IMapper = Atomiv.Core.Application.IMapper;
using Mapper = Atomiv.Infrastructure.AutoMapper.Mapper;

namespace Atomiv.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Scan assemblies for Mapster configurations
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(assemblies);
            
            services.AddScoped<IMapper, Mapper>();

            return services;
        }
    }
}