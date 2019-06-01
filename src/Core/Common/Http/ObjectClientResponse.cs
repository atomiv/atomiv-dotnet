using System.Net;

namespace Optivem.Core.Common.Http
{
    public class ObjectClientResponse<T> : IObjectClientResponse<T>
    {
        public ObjectClientResponse(IClientResponse response, T content, IProblemDetails problemDetails)
            : this(response.IsSuccessStatusCode, response.StatusCode, response.ContentString, content, problemDetails) { }

        public ObjectClientResponse(bool isSuccessStatusCode, HttpStatusCode statusCode, string contentString, T content, IProblemDetails problemDetails)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            StatusCode = statusCode;
            ContentString = contentString;
            Content = content;
            ProblemDetails = problemDetails;
        }

        public bool IsSuccessStatusCode { get; }

        public HttpStatusCode StatusCode { get; }

        public string ContentString { get; }

        public T Content { get; }

        public IProblemDetails ProblemDetails { get; }
    }
}
