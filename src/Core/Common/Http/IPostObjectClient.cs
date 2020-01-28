using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IPostObjectClient
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request);

        Task PostAsync<TRequest>(string uri, TRequest request);
    }

    public interface IPostObjectClient<TRequest, TResponse>
    {
        Task<TResponse> PostAsync(string uri, TRequest request);
    }

    public interface IPostObjectClient<TRequest>
    {
        Task PostAsync(string uri, TRequest request);
    }
}