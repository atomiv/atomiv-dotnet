using System.Net;

namespace Atomiv.Core.Common.Http
{
    public class ObjectClientResponse<T> : ClientResponse
    {
        public ObjectClientResponse(bool isSuccessStatusCode, HttpStatusCode statusCode, string contentString, T content, IProblemDetails problemDetails)
            : base(isSuccessStatusCode, statusCode, contentString)
        {
            Data = content;
            ProblemDetails = problemDetails;
        }

        public ObjectClientResponse(ClientResponse response, T content, IProblemDetails problemDetails)
            : this(response.IsSuccessStatusCode, response.StatusCode, response.ContentString, content, problemDetails) { }

        public T Data { get; }

        public IProblemDetails ProblemDetails { get; }
    }
}