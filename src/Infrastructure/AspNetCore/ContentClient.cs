using Optivem.Framework.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.AspNetCore
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

        public Task<string> DeleteAsync(string uri)
        {
            return ExecuteAsync(e => e.DeleteAsync(uri));
        }

        public void Dispose()
        {
            Client.Dispose();
        }

        public Task<string> GetAsync(string uri, string acceptType)
        {
            return ExecuteAsync(e => e.GetAsync(uri, acceptType));
        }

        public Task<string> GetAsync(string uri)
        {
            return ExecuteAsync(e => e.GetAsync(uri));
        }

        public Task<string> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            return ExecuteAsync(e => e.PostAsync(uri, content, contentType, acceptType));
        }

        public Task<string> PostAsync(string uri, string content, string contentType)
        {
            return ExecuteAsync(e => e.PostAsync(uri, content, contentType));
        }

        public Task<string> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            return ExecuteAsync(e => e.PutAsync(uri, content, contentType, acceptType));
        }

        public Task<string> PutAsync(string uri, string content, string contentType)
        {
            return ExecuteAsync(e => e.PutAsync(uri, content, contentType));
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