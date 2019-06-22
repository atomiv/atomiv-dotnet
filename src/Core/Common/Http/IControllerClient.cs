using System.Threading.Tasks;

namespace Optivem.Core.Common.Http
{
    // TODO: VC: Sub-resources for all operations, enabling additional uri, also enabling fully custom uri in case no patterns match

    public interface IControllerClient : IObjectClient, IClient
    {
        Task<IObjectClientResponse<TResponse>> GetAsync<TRequest, TResponse>(TRequest request);

        Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>();

        Task<IClientResponse> GetAsync();

        Task<IObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id);

        Task<IClientResponse> GetByIdAsync<TId>(TId id);

        Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request);

        Task<IClientResponse> PostAsync<TRequest>(TRequest request);

        Task<IObjectClientResponse<TResponse>> PostSubAsync<TRequest, TResponse>(string uri, TRequest request);

        Task<IObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request);

        Task<IClientResponse> PutByIdAsync<TId, TRequest>(TId id, TRequest request);

        Task<IObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id);

        Task<IClientResponse> DeleteByIdAsync<TId>(TId id);
    }
}