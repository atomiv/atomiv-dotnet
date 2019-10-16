using System.Net;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IClientResponse
    {
        bool IsSuccessStatusCode { get; }

        HttpStatusCode StatusCode { get; }

        string ContentString { get; }
    }
}