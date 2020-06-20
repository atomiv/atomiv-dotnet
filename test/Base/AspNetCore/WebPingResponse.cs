using System.Net;

namespace Atomiv.Test.AspNetCore
{
    public class WebPingResponse
    {
        public WebPingResponse(bool success, HttpStatusCode statusCode, string content)
        {
            Success = success;
            StatusCode = statusCode;
            Content = content;
        }

        public bool Success { get; }

        public HttpStatusCode StatusCode { get; }

        public string Content { get; }
    }
}