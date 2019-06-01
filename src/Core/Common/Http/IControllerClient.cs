using System.Threading.Tasks;

namespace Optivem.Core.Common.Http
{
    public interface IControllerClient : IObjectClient, IClient
    {
        Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>();

        Task<IClientResponse> GetAsync();

        Task<IObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id);

        Task<IClientResponse> GetByIdAsync<TId>(TId id);

        Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request);

        Task<IClientResponse> PostAsync<TRequest>(TRequest request);

        Task<IObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request);

        Task<IClientResponse> PutByIdAsync<TId, TRequest>(TId id, TRequest request);

        Task<IObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id);

        Task<IClientResponse> DeleteByIdAsync<TId>(TId id);
    }
}