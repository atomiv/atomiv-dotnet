using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Application;
using System.Net;

namespace Optivem.Framework.Web.AspNetCore.ExceptionProblemDetailsFactories
{
    public class RequestNotFoundExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<ExistenceException, ProblemDetails>
    {
        // TODO: VC: Set text

        protected override string GetDetail(ExistenceException exception)
        {
            return "Not found ex details";
        }

        protected override string GetProblemTypeUri(ExistenceException exception)
        {
            return "Not found ex uri";
        }

        protected override int GetStatus(ExistenceException exception)
        {
            return (int)HttpStatusCode.NotFound;
        }

        protected override string GetTitle(ExistenceException exception)
        {
            return "Not found ex title";
        }
    }
}