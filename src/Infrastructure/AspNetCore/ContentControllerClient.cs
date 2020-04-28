using Optivem.Atomiv.Core.Common.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ContentControllerClient : IContentControllerClient
    {
        public ContentControllerClient(IControllerClient client)
        {
            Client = client;
        }

        public IControllerClient Client { get; }

        public Task<TResponse> DeleteAsync<TResponse>(string uri)
        {
            return ExecuteAsync(e => e.DeleteAsync<TResponse>(uri));
        }

        public Task<string> DeleteAsync(string uri, IEnumerable<RequestHeader> headers)
        {
            return ExecuteAsync(e => e.DeleteAsync(uri, headers));
        }

        public Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetAsync<TResponse>()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetAsync<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string uri, IEnumerable<RequestHeader> headers)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetByIdAsync<TId, TResponse>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PostAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PostAsync<TRequest>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PostAsync(string uri, string content, IEnumerable<RequestHeader> headers)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostSubAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PutAsync<TRequest>(string uri, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PutAsync(string uri, string content, IEnumerable<RequestHeader> headers)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PutByIdAsync<TId, TRequest>(TId id, TRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(Func<IControllerClient, Task<ObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Client);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }

        private async Task<string> ExecuteAsync(Func<IControllerClient, Task<ClientResponse>> action)
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