using System.Threading.Tasks;

namespace Optivem.Core.Common.Http
{
    public interface IObjectClient
    {
        Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri);

        Task<IClientResponse> GetAsync(string uri);

        Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<IClientResponse> PostAsync<TRequest>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<IClientResponse> PutAsync<TRequest>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri);

        Task<IClientResponse> DeleteAsync(string uri);
    }
}