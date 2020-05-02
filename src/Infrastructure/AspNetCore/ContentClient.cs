using Optivem.Atomiv.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ContentClient : IContentClient
    {
        public ContentClient(IClient client)
        {
            Client = client;
        }

        public IClient Client { get; }

        public Task<string> DeleteAsync(string uri, RequestHeaderCollection headers)
        {
            return ExecuteAsync(e => e.DeleteAsync(uri, headers));
        }

        public Task<string> GetAsync(string uri, RequestHeaderCollection headers)
        {
            return ExecuteAsync(e => e.GetAsync(uri, headers));
        }

        public Task<string> PostAsync(string uri, string content, RequestHeaderCollection headers)
        {
            return ExecuteAsync(e => e.PostAsync(uri, content, headers));
        }

        public Task<string> PutAsync(string uri, string content, RequestHeaderCollection headers)
        {
            return ExecuteAsync(e => e.PutAsync(uri, content, headers));
        }

        private async Task<string> ExecuteAsync(Func<IClient, Task<ClientResponse>> action)
        {
            var response = await action(Client);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.ContentString;
        }
    }
}