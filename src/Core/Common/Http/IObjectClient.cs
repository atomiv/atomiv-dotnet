using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IObjectClient
    {
        Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri);

        // TODO: VC: DELETE this + impl
        // Task<IClientResponse> GetAsync(string uri);

        Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> PostAsync<TResponse>(string uri);

        Task<IClientResponse> PostNoResponseAsync<TRequest>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<IClientResponse> PutNoResponseAsync<TRequest>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri);

        // TODO: VC: DELETE this + impl
        // Task<IClientResponse> DeleteAsync(string uri);
    }
}