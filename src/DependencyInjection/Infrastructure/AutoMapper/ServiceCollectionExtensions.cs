using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using IMapper = Optivem.Framework.Core.Application.Mapping.IMapper;
using Mapper = Optivem.Framework.Infrastructure.AutoMapper.Mapper;

namespace Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper
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