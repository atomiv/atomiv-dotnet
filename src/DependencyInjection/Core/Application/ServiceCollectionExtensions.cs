using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Optivem.DependencyInjection.Core.Application
{
    public static class ServiceCollectionExtensions
    {
        private static Type UseCaseType = typeof(IUseCase<,>);

        public static IServiceCollection AddApplicationCore(this IServiceCollection services, IEnumerable<Type> types)
        {
            var classes = types.GetConcreteImplementingTypes(UseCaseType);

            services.AddTransient(UseCaseType, classes);

            return services;
        }

        /*
         * 
            services.AddScoped<IUseCase<ListCustomersRequest, ListCustomersResponse>, ListCustomersUseCase>();
            services.AddScoped<IUseCase<FindCustomerRequest, FindCustomerResponse>, FindCustomerUseCase>();
         * 
         * 
         */

    }
}
