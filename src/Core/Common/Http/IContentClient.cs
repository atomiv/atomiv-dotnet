using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Http
{
    public interface IContentClient : IDisposable
    {
        Task<string> GetAsync(string uri, string acceptType);

        Task<string> GetAsync(string uri);

        Task<string> PostAsync(string uri, string content, string contentType, string acceptType);

        Task<string> PostAsync(string uri, string content, string contentType);

        Task<string> PutAsync(string uri, string content, string contentType, string acceptType);

        Task<string> PutAsync(string uri, string content, string contentType);

        Task<string> DeleteAsync(string uri, string acceptType);

        Task<string> DeleteAsync(string uri);
    }
}
