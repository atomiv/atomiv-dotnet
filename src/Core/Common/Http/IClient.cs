using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IClient
    {
        Task<ClientResponse> GetAsync(string uri, IEnumerable<RequestHeader> headers);

        Task<ClientResponse> PostAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<ClientResponse> PutAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<ClientResponse> DeleteAsync(string uri, IEnumerable<RequestHeader> headers);
    }
}