using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IClient
    {
        Task<IClientResponse> GetAsync(string uri, IEnumerable<RequestHeader> headers);

        Task<IClientResponse> PostAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<IClientResponse> PutAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<IClientResponse> DeleteAsync(string uri, IEnumerable<RequestHeader> headers);
    }
}