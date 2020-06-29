using Atomiv.Core.Application;
using Atomiv.Core.Common.Serialization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Atomiv.Web.AspNetCore
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly IJsonSerializer _serializer;
        private readonly IRootExceptionProblemDetailsFactory _factory;

        public ExceptionHandler(IJsonSerializer serializer, IRootExceptionProblemDetailsFactory factory)
        {
            _serializer = serializer;
            _factory = factory;
        }


        // TODO: VC: Check if the http context can be outside? From accessor?
        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            // TODO: VC: Consider if this fails, perhaps outer try-catch?

            // Unauthorized

            if (exception.GetType() == typeof(AuthorizationException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return;
            }

            // NotFound

            // TODO: VC: Check if NotFound should be here or move below

            if (exception.GetType() == typeof(ExistenceException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }

            // UnprocessableEntity

            var problemDetails = _factory.Create(exception);

            if (problemDetails != null)
            {
                var instance = problemDetails.Instance;

                // TODO: VC: Fix logging
                // var logger = context.RequestServices.GetRequiredService<ILogger>();
                // logger.LogError(exception, exception.Message);

                context.Response.StatusCode = problemDetails.Status.Value;

                // TODO: VC: Lookup json service from services
                await context.Response.WriteJsonAsync(problemDetails, _serializer);
            }
        }
    }
}
