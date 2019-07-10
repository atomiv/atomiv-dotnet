using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Common.Serialization;
using System.Threading.Tasks;

namespace Optivem.Framework.Web.AspNetCore
{
    public class ValidationProblemDetailsActionResult : IActionResult
    {
        private IActionContextProblemDetailsFactory<ValidationProblemDetails> _factory;
        private IJsonSerializer _jsonSerializationService;

        public ValidationProblemDetailsActionResult(IActionContextProblemDetailsFactory<ValidationProblemDetails> factory,
            IJsonSerializer jsonSerializationService)
        {
            _factory = factory;
            _jsonSerializationService = jsonSerializationService;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var problemDetails = _factory.Create(context);
            context.HttpContext.Response.StatusCode = problemDetails.Status.Value;
            return context.HttpContext.Response.WriteJsonAsync(problemDetails, _jsonSerializationService);
        }
    }
}