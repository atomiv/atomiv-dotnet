using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Optivem.Platform.Core.Common.Mapping;
using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Profiles.Customers;
using Optivem.Platform.Web.AspNetCore.Rest;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake
{
    public class Startup
    {
        private static bool DefaultCanProvideExceptionInfo = true;

        private const string DefaultTitle = "An error had occurred";
        private const string DefaultDetail = "Please contact customer support and provide the instance identifier";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICsvSerializationService, CsvSerializationService>();

            services.AddScoped<IMappingService, AutoMapperMappingService>();

            // Mapping
            // TODO: VC: DELETE

            /*
            services.AddAutoMapper(e =>
            {
                e.AddProfile<CustomerGetCollectionResponseProfile>();
            });
            */

            services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomerGetCollectionResponseProfile)));

            // TODO: VC: AutoMapper: AssertConfigurationIsValid (example error: Count field is not mapped)

            services
                .AddMvc(options =>
                {
                    ICsvSerializationService csvSerializationService = new CsvSerializationService();

                    // TODO: VC: Consider using from resolver...
                    options.InputFormatters.Add(new CsvInputFormatter(csvSerializationService));
                    options.OutputFormatters.Add(new CsvOutputFormatter(csvSerializationService));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Fake API", Version = "v1" });
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

            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;

                    var instance = GetInstance();

                    // TODO: VC: Fix logging
                    // var logger = context.RequestServices.GetRequiredService<ILogger>();
                    // logger.LogError(exception, exception.Message);

                    // TODO: Condition whether to return stack trace, context.Request.IsTrusted()

                    int status = GetStatus(exception);
                    var title = GetTitle(context.Request, exception);
                    var detail = GetDetail(context.Request, exception);
                    var type = GetType(exception);

                    // TODO: VC: Implement
                    // var extensions = GetExtensions(exception);

                    var problemDetails = new ProblemDetails
                    {
                        Title = exception.Message,
                        Status = status,
                        Detail = exception.StackTrace,
                        Instance = instance,
                        Type = type,
                        // Extensions = extensions,
                    };

                    context.Response.StatusCode = problemDetails.Status.Value;

                    // TODO: VC: Lookup from services
                    IJsonSerializationService jsonSerializationService = new JsonSerializationService();
                    var json = jsonSerializationService.Serialize(problemDetails);

                    // TODO: VC: make configurable
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(json);
                });

            });

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Fake API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();


        }

        private static string GetTitle(HttpRequest request, Exception ex)
        {
            var canProvideExceptionInfo = CanProvideExceptionInfo(request);

            if (canProvideExceptionInfo)
            {
                return ex.Message;
            }
            else
            {
                return DefaultTitle;
            }
        }

        private static string GetDetail(HttpRequest request, Exception ex)
        {
            var canProvideExceptionInfo = CanProvideExceptionInfo(request);

            if(canProvideExceptionInfo)
            {
                return ex.Demystify().ToString();
            }
            else
            {
                return DefaultDetail;
            }
        }

        private static bool CanProvideExceptionInfo(HttpRequest request)
        {
            // TODO: VC: Implementing context.Request.IsTrusted() to determin whether to 

            return DefaultCanProvideExceptionInfo;
        }

        private static int GetStatus(Exception exception)
        {
            if (exception is BadHttpRequestException badHttpRequestException)
            {
                return badHttpRequestException.StatusCode;
            }


            return (int)HttpStatusCode.InternalServerError;
        }

        private static string GetInstance()
        {
            var guid = Guid.NewGuid();

            // TODO: VC: #177: REST API - Exception Handling - Problem Details - Instance
            var instance = $"urn:optivem:error:{guid}";

            return instance;
        }

        private static string GetType(Exception exception)
        {
            // TODO: VC: #176: REST API - Exception Handling - Problem Details - Type
            return null;
        }

        private static IDictionary<string, object> GetExtensions(Exception exception)
        {
            return null;
        }
    }
}
