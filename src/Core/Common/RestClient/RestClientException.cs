using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Optivem.Platform.Core.Common.RestClient
{
    public class RestClientException : Exception
    {
        public RestClientException()
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

        public RestClientException(HttpStatusCode statusCode, string content)
            : this(GetMessage(statusCode, content))
        {
        }

        private static string GetMessage(HttpStatusCode statusCode, string content)
        {
            return $"Failed with status code {statusCode} with content {content}";
        }
    }
}
