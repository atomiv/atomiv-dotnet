using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using IMapper = Atomiv.Core.Application.IMapper;
using Mapper = Atomiv.Infrastructure.AutoMapper.Mapper;

namespace Atomiv.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IMapper, Mapper>();

            return services;
        }
    }
}