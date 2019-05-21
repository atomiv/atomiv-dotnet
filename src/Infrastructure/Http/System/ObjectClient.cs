using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Http.System
{
    public class ObjectClient : IObjectClient
    {
        public ObjectClient(IClient client, IFormatSerializationService serializationService, string acceptType, string contentType, Encoding encoding)
        {
            Client = client;
            SerializationService = serializationService;
            AcceptType = acceptType;
            ContentType = contentType;
            DefaultEncoding = encoding;
        }

        public ObjectClient(IClient client, IFormatSerializationService serializationService, string acceptType, string contentType)
            : this(client, serializationService, acceptType, contentType, Encoding.UTF8) { }

        // TODO: VC: Base uri, can be null or filled in, useful for controllers

        public IClient Client { get; private set; }

        public IFormatSerializationService SerializationService { get; private set; }

        public string AcceptType { get; private set; }

        public string ContentType { get; private set; }

        public Encoding DefaultEncoding { get; private set; }

        public async Task<TResponse> GetAsync<TResponse>(string uri)
        {
            var response = await Client.GetAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task GetAsync(string uri)
        {
            return Client.GetAsync(uri);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PostAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task PostAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PostAsync(uri, content, ContentType);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PutAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task PutAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PutAsync(uri, content, ContentType);
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string uri)
        {
            var response = await Client.DeleteAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task DeleteAsync(string uri)
        {
            return Client.DeleteAsync(uri);
        }

        #region Helper

        private string Serialize<T>(T data)
        {
            return SerializationService.Serialize(data);
        }

        private T Deserialize<T>(string data)
        {
            return SerializationService.Deserialize<T>(data);
        }

        public Task<TResponse> GetAsync<TResponse>()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync()
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

        #endregion Helper
    }
}