using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IContentClient
    {
        Task<string> GetAsync(string uri, string acceptType);

        Task<string> PostAsync(string uri, string content, string contentType, string acceptType);

        Task<string> PutAsync(string uri, string content, string contentType, string acceptType);

        Task<string> DeleteAsync(string uri, string acceptType);
    }
}