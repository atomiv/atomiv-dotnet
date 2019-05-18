using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Common.Http
{
    public interface IObjectClient
    {
        Task<TResponse> GetAsync<TResponse>(string uri);

        Task GetAsync(string uri);

        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request);

        Task PostAsync<TRequest>(string uri, TRequest request);

        Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request);

        Task PutAsync<TRequest>(string uri, TRequest request);

        Task<TResponse> DeleteAsync<TResponse>(string uri);

        Task DeleteAsync(string uri);
    }
}
