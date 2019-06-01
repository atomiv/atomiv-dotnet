using Microsoft.AspNetCore.Mvc;
using Optivem.Core.Application;
using System.Net;

namespace Optivem.Web.AspNetCore.ExceptionProblemDetailsFactories
{
    public class RequestNotFoundExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<RequestNotFoundException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(RequestNotFoundException exception)
        {
            return "Not found ex details";
        }

        protected override string GetProblemTypeUri(RequestNotFoundException exception)
        {
            return "Not found ex uri";
        }

        protected override int GetStatus(RequestNotFoundException exception)
        {
            return (int)HttpStatusCode.NotFound;
        }

        protected override string GetTitle(RequestNotFoundException exception)
        {
            return "Not found ex title";
        }
    }
}
