using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IContentControllerClient : IContentObjectClient, IContentClient
    {
        Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request);

        Task<TResponse> GetAsync<TResponse>();

        Task<string> GetAsync();

        Task<TResponse> GetByIdAsync<TId, TResponse>(TId id);

        Task<string> GetByIdAsync<TId>(TId id);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request);

        Task<string> PostAsync<TRequest>(TRequest request);

        Task<TResponse> PostSubAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request);

        Task<string> PutByIdAsync<TId, TRequest>(TId id, TRequest request);

        Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id);

        Task<string> DeleteByIdAsync<TId>(TId id);
    }
}
