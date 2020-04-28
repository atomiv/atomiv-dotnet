using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IClient
    {
        Task<ClientResponse> GetAsync(string uri, RequestHeaderCollection headers = null);

        Task<ClientResponse> PostAsync(string uri, string content, RequestHeaderCollection headers = null);

        Task<ClientResponse> PutAsync(string uri, string content, RequestHeaderCollection headers = null);

        Task<ClientResponse> DeleteAsync(string uri, RequestHeaderCollection headers = null);
    }
}