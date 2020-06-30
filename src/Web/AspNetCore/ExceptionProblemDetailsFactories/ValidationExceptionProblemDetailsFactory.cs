using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Application;
using System.Net;

namespace Atomiv.Web.AspNetCore
{
    public class ValidationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<ValidationException, ProblemDetails>
    {
        private const HttpStatusCode StatusCode = HttpStatusCode.UnprocessableEntity;
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc4918#section-11.2";

        public ValidationExceptionProblemDetailsFactory() 
            : base(StatusCode, ProblemTypeUri)
        {
        }
    }
}