using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Infrastructure.AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.Framework.DependencyInjection.Infrastructure.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        private static Type ResponseProfileType = typeof(ResponseProfile<,>);
        private static Type EnumerableType = typeof(IEnumerable);

        private static Type ResponseMapperInterfaceType = typeof(IResponseMapper<,>);
        private static Type ResponseMapperImplementationType = typeof(ResponseMapper<,>);

        private static Type CollectionResponseMapperInterfaceType = typeof(ICollectionResponseMapper<,>);
        private static Type CollectionResponseMapperImplementationType = typeof(CollectionResponseMapper<,>);

        public static IServiceCollection AddAutoMapperInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            services.AddScoped<IResponseMapper, ResponseMapper>();

            var types = assemblies.GetTypes();
            services.AddRequestMappers(types);

            return services;
        }

        private static IServiceCollection AddRequestMappers(this IServiceCollection services, IEnumerable<Type> types)
        {
            var profileImplementations = types.GetSubclassesOfGenericClass(ResponseProfileType);

            foreach(var profileImplementation in profileImplementations)
            {
                services.AddRequestMapper(profileImplementation);
            }

            return services;
        }
        private static IServiceCollection AddRequestMapper(this IServiceCollection services, Type profileType)
        {
            var responseProfileType = profileType.BaseType;
            var sourceType = responseProfileType.GenericTypeArguments[0];
            var responseType = responseProfileType.GenericTypeArguments[1];

            var responseMapperServiceType = ResponseMapperInterfaceType.MakeGenericType(sourceType, responseType);
            var responseMapperImplementationType = ResponseMapperImplementationType.MakeGenericType(sourceType, responseType);

            services.AddScoped(responseMapperServiceType, responseMapperImplementationType);

            var isEnumerableSource = sourceType.ImplementsInterface(EnumerableType);

            if (isEnumerableSource)
            {
                var sourceElementType = sourceType.GenericTypeArguments[0];
                var collectionResponseMapperServiceType = CollectionResponseMapperInterfaceType.MakeGenericType(sourceElementType, responseType);
                var collectionResponseMapperImplementationType = CollectionResponseMapperImplementationType.MakeGenericType(sourceElementType, responseType);

                services.AddScoped(collectionResponseMapperServiceType, collectionResponseMapperImplementationType);
            }

            return services;
        }
    }
}
