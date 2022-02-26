using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.Web.AspNetCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Atomiv.Template.Web.RestApi.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseProblemDetailsExceptionHandler(this IApplicationBuilder app, IExceptionProblemDetailsFactory problemDetailsFactory = null)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                AllowStatusCode404Response = true,
                ExceptionHandler = context => app.HandleExceptionAsync(context),
            });

            return app;
        }

        private static async Task HandleExceptionAsync(this IApplicationBuilder app, HttpContext context)
        {
            try
            {
                var exceptionHandler = app.ApplicationServices.GetRequiredService<IExceptionHandler>();

                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = exceptionHandlerFeature.Error;

                await exceptionHandler.HandleAsync(context, exception);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
