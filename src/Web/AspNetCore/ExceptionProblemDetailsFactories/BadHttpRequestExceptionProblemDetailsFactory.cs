using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace Atomiv.Web.AspNetCore
{
    public class BadHttpRequestExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<BadHttpRequestException, ProblemDetails>
    {
        private const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc7231#section-6.5.1";

        public BadHttpRequestExceptionProblemDetailsFactory() 
            : base(StatusCode, ProblemTypeUri)
        {
        }

        protected override int GetStatus(BadHttpRequestException exception)
        {
            return exception.StatusCode;
        }
    }
}