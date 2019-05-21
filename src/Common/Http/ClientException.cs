using System;
using System.Net;

namespace Optivem.Common.Http
{
    public class ClientException : Exception
    {
        public ClientException(HttpStatusCode statusCode, string content, Exception innerException)
            : base(GetMessage(statusCode, content), innerException)
        {
            StatusCode = statusCode;
            Content = content;
        }

        public ClientException(HttpStatusCode statusCode, string content)
            : this(statusCode, content, null) { }

        public HttpStatusCode StatusCode { get; private set; }

        public string Content { get; private set; }

        private static string GetMessage(HttpStatusCode statusCode, string content)
        {
            return $"Failed with status code {statusCode} with content {content}";
        }
    }
}
