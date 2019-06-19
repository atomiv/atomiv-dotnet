using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.MediatR;
using System;
using Optivem.Web.AspNetCore;
using Optivem.Core.Common.Serialization;
using Optivem.Infrastructure.NewtonsoftJson;
using Optivem.DependencyInjection.Core.Application;
using Optivem.DependencyInjection.Core.Domain;
using Optivem.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.DependencyInjection.Infrastructure.MediatR;
using Optivem.Template.Infrastructure.MediatR.Customers;
using Optivem.Template.Infrastructure.AutoMapper.Customers;
using Optivem.Template.Infrastructure.FluentValidation.Customers;
using Optivem.Template.Core.Application.Customers.UseCases;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Application.Customers.Responses;
using System.Linq;
using System.Reflection;

namespace Optivem.Template.Web
{
    public class Startup
    {
        public const string DatabaseConnectionKey = "DefaultConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: VC: Lookup assembly by name

            // Core assemblies
            var applicationAssembly = typeof(CreateCustomerUseCase).Assembly;
            var domainAssembly = typeof(Customer).Assembly;

            // Infrastructure assemblies
            var entityFrameworkCoreAssembly = typeof(CustomerRepository).Assembly;
            var autoMapperAssembly = typeof(CreateCustomerResponseProfile).Assembly; // allAssemblies; // TODO: VC
            var fluentValidationAssembly = typeof(CreateCustomerRequestValidator).Assembly;
            var mediatRAssembly = typeof(CreateCustomerMediatorRequestHandler).Assembly;

            // TODO: VC: Move to base, automatic lookup of everything implementing IService, auto-DI

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mediatRAssemblies = typeof(CreateCustomerMediatorRequestHandler); // TODO: VC

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Core
            services.AddApplicationCore(applicationAssembly);
            services.AddDomainCore(domainAssembly);

            // Infrastructure
            var connection = Configuration.GetConnectionString(DatabaseConnectionKey);
            services.AddEntityFrameworkCoreInfrastructure<DatabaseContext, UnitOfWork>(options => options.UseSqlServer(connection), entityFrameworkCoreAssembly);
            services.AddAutoMapperInfrastructure(autoMapperAssembly);
            services.AddFluentValidationInfrastructure(fluentValidationAssembly);

            // Infrastructure - Messaging
            services.AddMediatRInfrastructure(mediatRAssembly);
            
            /*

            services.AddMediatR(mediatRAssemblies);
            services.AddScoped<IRequestHandler, MediatorRequestHandler>();
            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            // services.AddScoped<IPipelineBehavior<MediatorRequest<CreateCustomerRequest, CreateCustomerResponse>, CreateCustomerResponse>, ValidationPipelineBehavior<CreateCustomerRequest, CreateCustomerResponse>>();
            // services.AddScoped<IPipelineBehavior<MediatorRequest<UpdateCustomerRequest, UpdateCustomerResponse>, UpdateCustomerResponse>, ValidationPipelineBehavior<UpdateCustomerRequest, UpdateCustomerResponse>>();

            var pipelineBehaviorType = typeof(IPipelineBehavior<,>);
            var mediatorRequestType = typeof(MediatorRequest<,>);
            var validationPipelineBehaviorType = typeof(ValidationPipelineBehavior<,>);

            var useCaseImplementationType = typeof(CreateCustomerUseCase);

            var useCaseInterfaceTypes = useCaseImplementationType.GetTypeInfo().ImplementedInterfaces;
            

            var useCaseInterfaceType = useCaseInterfaceTypes.Single(e => e.Name == typeof(IUseCase<,>).Name);

            var requestType = useCaseInterfaceType.GenericTypeArguments[0];
            var responseType = useCaseInterfaceType.GenericTypeArguments[1];

            // var requestType = typeof(CreateCustomerRequest);
            // var responseType = typeof(CreateCustomerResponse);

            var mediatorRequestServiceType = mediatorRequestType.MakeGenericType(requestType, responseType);
            var pipelineBehaviorServiceType = pipelineBehaviorType.MakeGenericType(mediatorRequestServiceType, responseType);
            var validationPipelineBehaviorImplementationType = validationPipelineBehaviorType.MakeGenericType(requestType, responseType);

            services.AddScoped(pipelineBehaviorServiceType, validationPipelineBehaviorImplementationType);

            // services.AddScoped<IPipelineBehavior<MediatorRequest<CreateCustomerRequest, CreateCustomerResponse>, CreateCustomerResponse>, CreateCustomerValidationPipelineBehavior>();

            // TODO: VC: Loop through all the requests and their responses and register them in this way (perhaps loop through use cases and inspect request and response because it holds the pairs
            // TODO: VC: SImilarly for mediator requests, loop thrugh use cases... also don't need to gnerate code just directly use MediatorRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>

    */

            var validationProblemDetailsFactory = new ValidationActionContextProblemDetailsFactory();
            var jsonSerializationService = new JsonSerializationService();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx
                    => new ValidationProblemDetailsActionResult(validationProblemDetailsFactory, jsonSerializationService);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var registry = new ExceptionProblemDetailsFactoryRegistry(new SystemExceptionProblemDetailsFactory());
            registry.Add(new BadHttpRequestExceptionProblemDetailsFactory());
            registry.Add(new RequestValidationExceptionProblemDetailsFactory());

            var problemDetailsFactory = new ExceptionProblemDetailsFactory(registry);
            IJsonSerializationService jsonSerializationService = new JsonSerializationService();

            app.UseExceptionHandler(problemDetailsFactory, jsonSerializationService);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}