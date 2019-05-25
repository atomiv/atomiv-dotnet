using System.Net;

namespace Optivem.Common.Http
{
    public interface IClientResponse
    {
        bool IsSuccessStatusCode { get; }

        HttpStatusCode StatusCode { get; }

        string ContentString { get; }
    }
}
