using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using System.Net;

namespace Optivem.Framework.Web.AspNetCore
{
    public class RequestValidationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<ValidationException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(ValidationException exception)
        {
            return "Validation ex details";
        }

        protected override string GetProblemTypeUri(ValidationException exception)
        {
            return "Validation ex uri";
        }

        protected override int GetStatus(ValidationException exception)
        {
            return (int)HttpStatusCode.UnprocessableEntity;
        }

        protected override string GetTitle(ValidationException exception)
        {
            return "Validation ex title";
        }
    }
}