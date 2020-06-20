using Atomiv.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.AspNetCore
{
    public class ContentObjectClient : IContentObjectClient
    {
        public ContentObjectClient(IObjectClient client)
        {
            Client = client;
        }

        public IObjectClient Client { get; }

        public Task<TResponse> DeleteAsync<TResponse>(string uri, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.DeleteAsync<TResponse>(uri, headers));
        }

        public Task<TResponse> GetAsync<TResponse>(string uri, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.GetAsync<TResponse>(uri, headers));
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.PostAsync<TRequest, TResponse>(uri, request, headers));
        }

        public Task<string> PostAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.PostNoResponseAsync<TRequest>(uri, request, headers));
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.PutAsync<TRequest, TResponse>(uri, request, headers));
        }

        public Task<string> PutAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            return ExecuteAsync(e => e.PutNoResponseAsync<TRequest>(uri, request, headers));
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(Func<IObjectClient, Task<ObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Client);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }

        private async Task<string> ExecuteAsync(Func<IObjectClient, Task<ClientResponse>> action)
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