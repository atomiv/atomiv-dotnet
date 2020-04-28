using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    // TODO: VC: Sub-resources for all operations, enabling additional uri, also enabling fully custom uri in case no patterns match

    public interface IControllerClient : IObjectClient, IClient
    {
        Task<ObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(TRequest request);

        Task<ObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<ObjectClientResponse<TResponse>> GetAsync<TResponse>();

        Task<ClientResponse> GetNoResponseAsync();

        Task<ObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id);

        Task<ClientResponse> GetByIdNoResponseAsync<TId>(TId id);

        Task<ObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request);

        Task<ClientResponse> PostNoResponseAsync<TRequest>(TRequest request);

        Task<ObjectClientResponse<TResponse>> PostSubAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<ObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request);

        Task<ClientResponse> PutByIdNoResponseAsync<TId, TRequest>(TId id, TRequest request);

        Task<ObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id);

        Task<ClientResponse> DeleteByIdNoResponseAsync<TId>(TId id);
    }
}