using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class BadHttpRequestExceptionProblemDetailsFactory : BaseExceptionProblemDetailsFactory<BadHttpRequestException, ProblemDetails>
    {
        private const string Title = "Invalid request";

        protected override string GetDetail(BadHttpRequestException exception)
        {
            return exception.Message;
        }

        protected override string GetProblemTypeUri(BadHttpRequestException exception)
        {
            // TODO: VC: Provide uri
            return null;
        }

        protected override int GetStatus(BadHttpRequestException exception)
        {
            return exception.StatusCode;
        }

        protected override string GetTitle(BadHttpRequestException exception)
        {
            return Title;
        }
    }
}
