using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Common.Http
{
    public interface IClient : IDisposable
    {
        Task<string> GetAsync(string uri, string acceptType);

        Task GetAsync(string uri);

        Task<string> PostAsync(string uri, string content, string contentType, string acceptType);

        Task PostAsync(string uri, string content, string contentType);

        Task<string> PutAsync(string uri, string content, string contentType, string acceptType);

        Task PutAsync(string uri, string content, string contentType);

        Task<string> DeleteAsync(string uri, string acceptType);

        Task DeleteAsync(string uri);
    }
}
