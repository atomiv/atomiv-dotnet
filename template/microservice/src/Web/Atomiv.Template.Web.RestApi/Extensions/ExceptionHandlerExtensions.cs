using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.Core.Application;
using Atomiv.Core.Common.Serialization;
using Atomiv.Web.AspNetCore;
using System;
using System.Net;

namespace Atomiv.Template.Web.RestApi.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseProblemDetailsExceptionHandler(this IApplicationBuilder app, IExceptionProblemDetailsFactory problemDetailsFactory = null)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    try
                    {
                        var exceptionHandler = app.ApplicationServices.GetRequiredService<IExceptionHandler>();

                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = exceptionHandlerFeature.Error;

                        await exceptionHandler.HandleAsync(context, exception);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
            });

            return app;
        }
    }
}
