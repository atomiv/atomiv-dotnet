using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Optivem.Common.Http
{
    public class ProblemDetailsClientException : Exception
    {
        public ProblemDetailsClientException(HttpStatusCode statusCode, IProblemDetails problemDetails, Exception innerException)
            : base(GetMessage(statusCode, problemDetails), innerException)
        {
            StatusCode = statusCode;
            ProblemDetails = problemDetails;
        }

        public ProblemDetailsClientException(HttpStatusCode statusCode, IProblemDetails problemDetails)
            : this(statusCode, problemDetails, null) { }

        public HttpStatusCode StatusCode { get; private set; }

        public IProblemDetails ProblemDetails { get; private set; }

        private static string GetMessage(HttpStatusCode statusCode, IProblemDetails problemDetails)
        {
            return $"Failed with status code {statusCode} with content {problemDetails}";
        }
    }
}
