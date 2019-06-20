using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Web.AspNetCore;
using Optivem.Core.Common.Serialization;
using Optivem.DependencyInjection.Core.Application;
using Optivem.DependencyInjection.Core.Domain;
using Optivem.DependencyInjection.Infrastructure.AutoMapper;
using Optivem.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Optivem.DependencyInjection.Infrastructure.FluentValidation;
using Optivem.DependencyInjection.Infrastructure.MediatR;
using Optivem.DependencyInjection.Infrastructure.NewtonsoftJson;
using Optivem.Template.Infrastructure.EntityFrameworkCore;

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
            services.AddMvc()
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
            services.AddNewtonsoftJsonInfrastructure();
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

            app.UseProblemDetailsExceptionHandler();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}