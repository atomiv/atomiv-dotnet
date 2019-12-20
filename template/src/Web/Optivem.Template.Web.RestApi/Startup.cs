using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Template.DependencyInjection;

namespace Optivem.Template.Web.RestApi
{
    public class Startup
    {
        private const string SwaggerTitle = "Optivem.Template REST API";
        private const string SwaggerVersion = "v1";
        private const string SwaggerUrl = "../swagger/v1/swagger.json";

        private static readonly string SwaggerEndpointName = $"{SwaggerTitle} {SwaggerVersion}";
        private static readonly string SwaggerRoutePrefix = string.Empty;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddModules(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion, new OpenApiInfo { Title = SwaggerTitle, Version = SwaggerVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseProblemDetailsExceptionHandler();

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerUrl, SwaggerEndpointName);
                c.RoutePrefix = SwaggerRoutePrefix;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}