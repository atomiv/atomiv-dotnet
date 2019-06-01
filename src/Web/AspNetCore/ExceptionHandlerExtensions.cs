using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Optivem.Core.Common.Serialization;
using Optivem.Core.Application;
using System;
using System.Net;

namespace Optivem.Web.AspNetCore
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, IExceptionProblemDetailsFactory problemDetailsFactory, IJsonSerializationService jsonSerializationService)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    try
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = exceptionHandlerFeature.Error;

                        // TODO: VC: Consider if this fails, perhaps outer try-catch?

                        // NotFound

                        // TODO: VC: Check if NotFound should be here or move below

                        if(exception.GetType() == typeof(RequestNotFoundException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            return;
                        }

                        // UnprocessableEntity

                        var problemDetails = problemDetailsFactory.Create(exception);

                        if(problemDetails != null)
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
                    catch(Exception)
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