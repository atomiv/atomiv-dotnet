using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IContentClient
    {
        Task<string> GetAsync(string uri, RequestHeaderCollection headers = null);

        Task<string> PostAsync(string uri, string content, RequestHeaderCollection headers = null);

        Task<string> PutAsync(string uri, string content, RequestHeaderCollection headers = null);

        Task<string> DeleteAsync(string uri, RequestHeaderCollection headers = null);
    }
}