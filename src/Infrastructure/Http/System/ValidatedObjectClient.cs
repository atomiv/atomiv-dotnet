using Microsoft.AspNetCore.Mvc;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Http.System
{
    public class ValidatedObjectClient : IObjectClient
    {
        public ValidatedObjectClient(IObjectClient client, IFormatSerializationService serializationService)
        {
            Client = client;
            SerializationService = serializationService;
        }

        public IObjectClient Client { get; private set; }

        public IFormatSerializationService SerializationService { get; private set; }

        public Task<TResponse> GetAsync<TResponse>(string uri)
        {
            return ExecuteAsync(() => Client.GetAsync<TResponse>(uri));
        }

        public Task GetAsync(string uri)
        {
            return ExecuteAsync(() => Client.GetAsync(uri));
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            return ExecuteAsync(() => Client.PostAsync<TRequest, TResponse>(uri, request));
        }

        public Task PostAsync<TRequest>(string uri, TRequest request)
        {
            return ExecuteAsync(() => Client.PostAsync(uri, request));
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            return ExecuteAsync(() => Client.PutAsync<TRequest, TResponse>(uri, request));
        }

        public Task PutAsync<TRequest>(string uri, TRequest request)
        {
            return ExecuteAsync(() => Client.PutAsync(uri, request));
        }

        public Task<TResponse> DeleteAsync<TResponse>(string uri)
        {
            return ExecuteAsync(() => Client.DeleteAsync<TResponse>(uri));
        }

        public Task DeleteAsync(string uri)
        {
            return ExecuteAsync(() => Client.DeleteAsync(uri));
        }

        #region Helper

        private async Task ExecuteAsync(Func<Task> task)
        {
            try
            {
                await task();
            }
            catch (ClientException ex)
            {
                throw CreateProblemDetailsClientException(ex);
            }
        }

        private async Task<TResponse> ExecuteAsync<TResponse>(Func<Task<TResponse>> task)
        {
            try
            {
                return await task();
            }
            catch (ClientException ex)
            {
                throw CreateProblemDetailsClientException(ex);
            }
        }

        private ProblemDetailsClientException CreateProblemDetailsClientException(ClientException ex)
        {
            var statusCode = ex.StatusCode;
            var problemDetails = SerializationService.Deserialize<ProblemDetailsResponse>(ex.Content);

            return new ProblemDetailsClientException(statusCode, problemDetails, ex);
        }

        public Task<TResponse> GetAsync<TResponse>()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> GetByIdAsync<TId, TResponse>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task PutByIdAsync<TId, TRequest>(TId id, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
