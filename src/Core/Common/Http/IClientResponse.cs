using System.Net;

namespace Optivem.Core.Common.Http
{
    public interface IClientResponse
    {
        bool IsSuccessStatusCode { get; }

        HttpStatusCode StatusCode { get; }

        string ContentString { get; }
    }
}
