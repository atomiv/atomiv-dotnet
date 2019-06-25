using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IClient : IDisposable
    {
        Task<IClientResponse> GetAsync(string uri, string acceptType);

        Task<IClientResponse> GetAsync(string uri);

        Task<IClientResponse> PostAsync(string uri, string content, string contentType, string acceptType);

        Task<IClientResponse> PostAsync(string uri, string content, string contentType);

        Task<IClientResponse> PutAsync(string uri, string content, string contentType, string acceptType);

        Task<IClientResponse> PutAsync(string uri, string content, string contentType);

        Task<IClientResponse> DeleteAsync(string uri, string acceptType);

        Task<IClientResponse> DeleteAsync(string uri);
    }
}