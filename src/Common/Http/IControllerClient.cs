using System.Threading.Tasks;

namespace Optivem.Common.Http
{
    public interface IControllerClient : IObjectClient, IClient
    {
        Task<TResponse> GetAsync<TResponse>();

        Task GetAsync();

        Task<TResponse> GetByIdAsync<TId, TResponse>(TId id);

        Task GetByIdAsync<TId>(TId id);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request);

        Task PostAsync<TRequest>(TRequest request);

        Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request);

        Task PutByIdAsync<TId, TRequest>(TId id, TRequest request);

        Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id);

        Task DeleteByIdAsync<TId>(TId id);
    }
}