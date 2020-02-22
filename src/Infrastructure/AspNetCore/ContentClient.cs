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

        public Task<string> DeleteAsync(string uri, string acceptType)
        {
            return ExecuteAsync(e => e.DeleteAsync(uri, acceptType));
        }

        public Task<string> GetAsync(string uri, string acceptType)
        {
            return ExecuteAsync(e => e.GetAsync(uri, acceptType));
        }

        public Task<string> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            return ExecuteAsync(e => e.PostAsync(uri, content, contentType, acceptType));
        }

        public Task<string> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            return ExecuteAsync(e => e.PutAsync(uri, content, contentType, acceptType));
        }

        private async Task<string> ExecuteAsync(Func<IClient, Task<IClientResponse>> action)
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