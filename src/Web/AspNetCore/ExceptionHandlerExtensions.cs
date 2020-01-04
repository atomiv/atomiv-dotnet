using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Serialization;
using System;
using System.Net;

namespace Optivem.Framework.Web.AspNetCore
{
    public static class ExceptionHandlerExtensions
    {
        private static IExceptionProblemDetailsFactory GetDefaultProblemDetailsFactory()
        {
            var registry = new ExceptionProblemDetailsFactoryRegistry(new SystemExceptionProblemDetailsFactory());

            registry.Add(new BadHttpRequestExceptionProblemDetailsFactory());
            registry.Add(new RequestValidationExceptionProblemDetailsFactory());

            return new ExceptionProblemDetailsFactory(registry);
        }

        public static IApplicationBuilder UseProblemDetailsExceptionHandler(this IApplicationBuilder app, IExceptionProblemDetailsFactory problemDetailsFactory = null)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    try
                    {
                        var jsonSerializationService = app.ApplicationServices.GetRequiredService<IJsonSerializer>();

                        if (problemDetailsFactory == null)
                        {
                            problemDetailsFactory = GetDefaultProblemDetailsFactory();
                        }

                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = exceptionHandlerFeature.Error;

                        // TODO: VC: Consider if this fails, perhaps outer try-catch?

                        // NotFound

                        // TODO: VC: Check if NotFound should be here or move below

                        if (exception.GetType() == typeof(ExistenceException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            return;
                        }

                        // UnprocessableEntity

                        var problemDetails = problemDetailsFactory.Create(exception);

                        if (problemDetails != null)
                        {
                            var instance = problemDetails.Instance;

                            // TODO: VC: Fix logging
                            // var logger = context.RequestServices.GetRequiredService<ILogger>();
                            // logger.LogError(exception, exception.Message);

                            context.Response.StatusCode = problemDetails.Status.Value;

                            // TODO: VC: Lookup json service from services
                            await context.Response.WriteJsonAsync(problemDetails, jsonSerializationService);
                        }
                    }
                    catch (Exception)
                    {
                        // TODO: VC: Attempt log
                        throw;
                    }
                });
            });

            return app;
        }
    }
}