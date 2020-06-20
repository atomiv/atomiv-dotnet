using System.Threading.Tasks;

namespace Atomiv.Core.Common.Http
{
    public interface IContentObjectClient
    {
        Task<TResponse> GetAsync<TResponse>(string uri, HeaderDictionary headers = null);

        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null);

        Task<string> PostAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null);

        Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null);

        Task<string> PutAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null);

        Task<TResponse> DeleteAsync<TResponse>(string uri, HeaderDictionary headers = null);
    }
}