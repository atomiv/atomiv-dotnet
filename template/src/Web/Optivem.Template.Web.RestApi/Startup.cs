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
// using Optivem.Template.Infrastructure.MediatR.Customers;
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Core
            services.AddApplicationCore();
            services.AddDomainCore();

            // Infrastructure
            var connection = Configuration.GetConnectionString(DatabaseConnectionKey);
            services.AddEntityFrameworkCoreInfrastructure<DatabaseContext, UnitOfWork>(options => options.UseSqlServer(connection));
            services.AddAutoMapperInfrastructure();
            services.AddFluentValidationInfrastructure();
            services.AddMediatRInfrastructure();

            /*
            var validationProblemDetailsFactory = new ValidationActionContextProblemDetailsFactory();
            var jsonSerializationService = new JsonSerializationService();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx
                    => new ValidationProblemDetailsActionResult(validationProblemDetailsFactory, jsonSerializationService);
            });
            */
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