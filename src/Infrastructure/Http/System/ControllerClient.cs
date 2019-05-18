using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Http.System
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

        public Task<TResponse> GetAsync<TResponse>()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task GetAsync()
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<TResponse> GetAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task GetAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<TResponse> GetByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync<TResponse>(relativeUri);
        }

        public Task GetByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.GetAsync(relativeUri);
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task PostAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PostAsync(relativeUri, request);
        }

        public Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task PostAsync<TRequest>(TRequest request)
        {
            var relativeUri = GetRelativeUri();
            return ObjectClient.PostAsync(relativeUri, request);
        }

        public Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task PutAsync<TRequest>(string uri, TRequest request)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<TResponse> PutByIdAsync<TId, TRequest, TResponse>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync<TRequest, TResponse>(relativeUri, request);
        }

        public Task PutByIdAsync<TId, TRequest>(TId id, TRequest request)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.PutAsync(relativeUri, request);
        }

        public Task<TResponse> DeleteAsync<TResponse>(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task DeleteAsync(string uri)
        {
            var relativeUri = GetRelativeUri(uri);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<TResponse> DeleteByIdAsync<TId, TResponse>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync<TResponse>(relativeUri);
        }

        public Task DeleteByIdAsync<TId>(TId id)
        {
            var relativeUri = GetRelativeUriById(id);
            return ObjectClient.DeleteAsync(relativeUri);
        }

        public Task<string> GetAsync(string uri, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.GetAsync(relativeUri, acceptType);
        }

        public Task<string> PostAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType, acceptType);
        }

        public Task PostAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PostAsync(relativeUri, content, contentType);
        }

        public Task<string> PutAsync(string uri, string content, string contentType, string acceptType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType, acceptType);
        }

        public Task PutAsync(string uri, string content, string contentType)
        {
            var relativeUri = GetRelativeUri(uri);
            return Client.PutAsync(relativeUri, content, contentType);
        }

        public Task<string> DeleteAsync(string uri, string acceptType)
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

        #endregion
    }
}
