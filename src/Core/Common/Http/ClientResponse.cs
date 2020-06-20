using System.Net;

namespace Atomiv.Core.Common.Http
{
    public class ClientResponse
    {
        public ClientResponse(bool isSuccessStatusCode, HttpStatusCode statusCode, string contentString)
        {
            IsSuccessStatusCode = isSuccessStatusCode;
            StatusCode = statusCode;
            ContentString = contentString;
        }

        public bool IsSuccessStatusCode { get; }

        public HttpStatusCode StatusCode { get; }

        public string ContentString { get; }
    }
}