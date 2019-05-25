using Microsoft.AspNetCore.Mvc;
using Optivem.Core.Application;
using System.Net;

namespace Optivem.Web.AspNetCore
{
    public class RequestValidationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<RequestValidationException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(RequestValidationException exception)
        {
            return "Validation ex details";
        }

        protected override string GetProblemTypeUri(RequestValidationException exception)
        {
            return "Validation ex uri";
        }

        protected override int GetStatus(RequestValidationException exception)
        {
            return (int)HttpStatusCode.UnprocessableEntity;
        }

        protected override string GetTitle(RequestValidationException exception)
        {
            return "Validation ex title";
        }
    }
}
