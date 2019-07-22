using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IContentObjectClient
    {
        Task<TResponse> GetAsync<TResponse>(string uri);

        // TODO: VC: DELETE this + impl
        // Task<string> GetAsync(string uri);

        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<string> PostAsync<TRequest>(string uri, TRequest request);

        Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<string> PutAsync<TRequest>(string uri, TRequest request);

        Task<TResponse> DeleteAsync<TResponse>(string uri);

        // TODO: VC: DELETE + impl
        // Task<string> DeleteAsync(string uri);
    }
}
