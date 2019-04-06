using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class SystemExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<Exception, ProblemDetails>
    {
        private const string Title = "An unexpected error had occurred";
        private const string Detail = "Please contact customer support and provide the instance identifier";

        private const int Status = (int)HttpStatusCode.InternalServerError;

        protected override string GetTitle(Exception exception)
        {
            return Title;
        }

        protected override string GetDetail(Exception exception)
        {
            return Detail;
        }

        protected override int GetStatus(Exception exception)
        {
            return Status;
        }

        protected override string GetProblemTypeUri(Exception exception)
        {
            // TODO: VC: #176: REST API - Exception Handling - Problem Details - Type
            return null;
        }

        // TODO: VC: Move

        /*
        private IDictionary<string, object> GetExtensions(Exception exception)
        {
            return null;
        }
        */
    }
}
