using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Atomiv.Core.Common.Serialization;
using Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson;
using Atomiv.Infrastructure.CsvHelper;
using Atomiv.Infrastructure.NewtonsoftJson;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Extensions;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Mapping;
using System.Reflection;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICsvSerializer, CsvSerializer>();

            // Configure Mapster
            MappingConfig.Configure();
            var config = new TypeAdapterConfig();
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddNewtonsoftJsonInfrastructure();

            // TODO: VC: AutoMapper: AssertConfigurationIsValid (example error: Count field is not mapped)

            services
                .AddMvc(options =>
                {
                    ICsvSerializer csvSerializationService = new CsvSerializer();

                    // TODO: VC: Consider using from resolver...
                    options.InputFormatters.Add(new CsvInputFormatter(csvSerializationService));
                    options.OutputFormatters.Add(new CsvOutputFormatter(csvSerializationService));

                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var validationProblemDetailsFactory = new ValidationActionContextProblemDetailsFactory();
            var jsonSerializationService = new JsonSerializer();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx
                    => new ValidationProblemDetailsActionResult(validationProblemDetailsFactory, jsonSerializationService);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Fake API", Version = "v1" });
            });

            services.AddSingleton<IExceptionProblemDetailsFactory, BadHttpRequestExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, ValidationExceptionProblemDetailsFactory>();
            services.AddSingleton<IExceptionProblemDetailsFactory, SystemExceptionProblemDetailsFactory>();
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Fake API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}