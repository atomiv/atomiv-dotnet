using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Optivem.Common.Serialization;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app, IExceptionProblemDetailsFactory problemDetailsFactory, IJsonSerializationService jsonSerializationService)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature.Error;

                    var problemDetails = problemDetailsFactory.Create(exception);

                    var instance = problemDetails.Instance;

                    // TODO: VC: Fix logging
                    // var logger = context.RequestServices.GetRequiredService<ILogger>();
                    // logger.LogError(exception, exception.Message);


                    context.Response.StatusCode = problemDetails.Status.Value;

                    // TODO: VC: Lookup json service from services
                    await context.Response.WriteJsonAsync(problemDetails, jsonSerializationService);
                });

            });

            return app;
        }
    }
}
