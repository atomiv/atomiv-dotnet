using Optivem.Common.Http;
using System;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.AspNetCore
{
    public class ControllerClient : IControllerClient
    {
        public ControllerClient(IClient client, IObjectClient objectClient, string controllerUri)
        {
            Client = client;
            ObjectClient = objectClient;
            ControllerUri = controllerUri;
        }

        public IClient Client { get; private set; }

        public IObjectClient ObjectClient { get; private set; }

        public string ControllerUri { get; private set; }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetAsync()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> GetByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> GetByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PostAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PostAsync<TRequest>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task<IClientResponse> PutByIdAsync<TId, TRequest>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<IObjectClientResponse<TResponse>> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task<IClientResponse> DeleteByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<IClientResponse> GetAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.GetAsync(relativeUri, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PostAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType, acceptType);
        }

        public Task<IClientResponse> PutAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType);
        }

        public Task<IClientResponse> DeleteAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.DeleteAsync(relativeUri, acceptType);
        }

        #region Helper

        private string GetRelativeUriById<TId>(TId id)
        {
            return $"{ControllerUri}/{id}";
        }

        private string GetRelativeUri(string uri = null)
        {
            if (uri == null)
            {
                return ControllerUri;
            }
            else
            {
                return $"{ControllerUri}/{uri}";
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion Helper
    }
}