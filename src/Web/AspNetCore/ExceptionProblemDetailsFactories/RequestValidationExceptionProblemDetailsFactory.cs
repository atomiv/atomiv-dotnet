using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using System.Net;

namespace Optivem.Framework.Web.AspNetCore
{
    public class RequestValidationExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<InvalidRequestException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(InvalidRequestException exception)
        {
            return "Validation ex details";
        }

        protected override string GetProblemTypeUri(InvalidRequestException exception)
        {
            return "Validation ex uri";
        }

        protected override int GetStatus(InvalidRequestException exception)
        {
            return (int)HttpStatusCode.UnprocessableEntity;
        }

        protected override string GetTitle(InvalidRequestException exception)
        {
            return "Validation ex title";
        }
    }
}