using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IContentControllerClient : IContentObjectClient, IContentClient
    {
        Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request, HeaderDictionary headers = null);

        Task<TResponse> GetAsync<TResponse>(HeaderDictionary headers = null);

        Task<string> GetAsync(HeaderDictionary headers = null);

        Task<TResponse> GetByIdAsync<TId, TResponse>(TId id, HeaderDictionary headers = null);

        Task<string> GetByIdAsync<TId>(TId id, HeaderDictionary headers = null);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, HeaderDictionary headers = null);

        Task<string> PostAsync<TRequest>(TRequest request, HeaderDictionary headers = null);

        Task<TResponse> PostSubAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null);

        Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request, HeaderDictionary headers = null);

        Task<string> PutByIdAsync<TId, TRequest>(TId id, TRequest request, HeaderDictionary headers = null);

        Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id, HeaderDictionary headers = null);

        Task<string> DeleteByIdAsync<TId>(TId id, HeaderDictionary headers = null);
    }
}