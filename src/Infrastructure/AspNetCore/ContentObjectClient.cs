using Optivem.Framework.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class ContentObjectClient : IContentObjectClient
    {
        public ContentObjectClient(IObjectClient client)
        {
            Client = client;
        }

        public IObjectClient Client { get; }

        public Task<TResponse> DeleteAsync<TResponse>(string uri)
        {
            return ExecuteAsync(e => e.DeleteAsync<TResponse>(uri));
        }

        public Task<TResponse> GetAsync<TResponse>(string uri)
        {
            return ExecuteAsync(e => e.GetAsync<TResponse>(uri));
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            return ExecuteAsync(e => e.PostAsync<TRequest, TResponse>(uri, request));
        }

        public Task<string> PostAsync<TRequest>(string uri, TRequest request)
        {
            return ExecuteAsync(e => e.PostAsync<TRequest>(uri, request));
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            return ExecuteAsync(e => e.PutAsync<TRequest, TResponse>(uri, request));
        }

        public Task<string> PutAsync<TRequest>(string uri, TRequest request)
        {
            return ExecuteAsync(e => e.PutAsync<TRequest>(uri, request));
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(Func<IObjectClient, Task<IObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Client);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }

        private async Task<string> ExecuteAsync(Func<IObjectClient, Task<IClientResponse>> action)
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