using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Application;
using System.Net;

namespace Atomiv.Web.AspNetCore
{
    public class RequestValidationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<ValidationException, ProblemDetails>
    {
        private const string ProblemTypeUri = "https://tools.ietf.org/html/rfc4918#section-11.2";
        private const HttpStatusCode Status = HttpStatusCode.UnprocessableEntity;

        protected override string GetDetail(ValidationException exception)
        {
            return exception.Message;
        }

        protected override string GetProblemTypeUri(ValidationException exception)
        {
            return ProblemTypeUri;
        }

        protected override int GetStatus(ValidationException exception)
        {
            return (int)Status;
        }

        protected override string GetTitle(ValidationException exception)
        {
            return Status.ToString();
        }
    }
}