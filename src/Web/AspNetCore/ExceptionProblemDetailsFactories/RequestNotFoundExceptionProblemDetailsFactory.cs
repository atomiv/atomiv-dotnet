using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using System.Net;

namespace Optivem.Framework.Web.AspNetCore.ExceptionProblemDetailsFactories
{
    public class RequestNotFoundExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<NotFoundRequestException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(NotFoundRequestException exception)
        {
            return "Not found ex details";
        }

        protected override string GetProblemTypeUri(NotFoundRequestException exception)
        {
            return "Not found ex uri";
        }

        protected override int GetStatus(NotFoundRequestException exception)
        {
            return (int)HttpStatusCode.NotFound;
        }

        protected override string GetTitle(NotFoundRequestException exception)
        {
            return "Not found ex title";
        }
    }
}
