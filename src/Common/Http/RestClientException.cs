using System;
using System.Net;
using System.Runtime.Serialization;

namespace Optivem.Core.Common.RestClient
{
    public class RestClientException : Exception
    {
        public RestClientException() : base()
        {
        }
        
        public RestClientException(string message) : base(message)
        {
        }

        public RestClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RestClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RestClientException(HttpStatusCode statusCode, string content, IProblemDetails problemDetails)
            : this(GetMessage(statusCode, content))
        {
            StatusCode = statusCode;
            Content = content;
            ProblemDetails = problemDetails;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string Content { get; private set; }

        public IProblemDetails ProblemDetails { get; private set; }

        private static string GetMessage(HttpStatusCode statusCode, string content)
        {
            return $"Failed with status code {statusCode} with content {content}";
        }
    }
}
