using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using IMapper = Optivem.Atomiv.Core.Application.IMapper;
using Mapper = Optivem.Atomiv.Infrastructure.AutoMapper.Mapper;

namespace Optivem.Atomiv.DependencyInjection.Infrastructure.AutoMapper
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