using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Atomiv.Web.AspNetCore
{
    public class SystemExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<Exception, ProblemDetails>
    {
        private const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc7231#section-6.6.1";

        public SystemExceptionProblemDetailsFactory() 
            : base(StatusCode, ProblemTypeUri)
        {
        }
    }
}