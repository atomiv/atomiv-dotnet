using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IContentControllerClient : IContentObjectClient, IContentClient
    {
        Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request, RequestHeaderCollection headers = null);

        Task<TResponse> GetAsync<TResponse>(RequestHeaderCollection headers = null);

        Task<string> GetAsync(RequestHeaderCollection headers = null);

        Task<TResponse> GetByIdAsync<TId, TResponse>(TId id, RequestHeaderCollection headers = null);

        Task<string> GetByIdAsync<TId>(TId id, RequestHeaderCollection headers = null);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, RequestHeaderCollection headers = null);

        Task<string> PostAsync<TRequest>(TRequest request, RequestHeaderCollection headers = null);

        Task<TResponse> PostSubAsync<TRequest, TResponse>(string uri, TRequest request, RequestHeaderCollection headers = null);

        Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request, RequestHeaderCollection headers = null);

        Task<string> PutByIdAsync<TId, TRequest>(TId id, TRequest request, RequestHeaderCollection headers = null);

        Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id, RequestHeaderCollection headers = null);

        Task<string> DeleteByIdAsync<TId>(TId id, RequestHeaderCollection headers = null);
    }
}