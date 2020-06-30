using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Application;
using System.Net;

namespace Atomiv.Web.AspNetCore.ExceptionProblemDetailsFactories
{
    public class ExistenceExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<ExistenceException, ProblemDetails>
    {
        private const HttpStatusCode StatusCode = HttpStatusCode.NotFound;
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc7231#section-6.5.4";

        public ExistenceExceptionProblemDetailsFactory() 
            : base(StatusCode, ProblemTypeUri)
        {
        }
    }
}