using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IContentClient
    {
        Task<string> GetAsync(string uri, IEnumerable<RequestHeader> headers);

        Task<string> PostAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<string> PutAsync(string uri, string content, IEnumerable<RequestHeader> headers);

        Task<string> DeleteAsync(string uri, IEnumerable<RequestHeader> headers);
    }
}