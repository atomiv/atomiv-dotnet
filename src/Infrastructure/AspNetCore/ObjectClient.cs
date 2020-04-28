using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ObjectClient : IObjectClient
    {
        public ObjectClient(IClient client, IFormatSerializer serializer, IEnumerable<RequestHeader> headers, Encoding encoding)
        {
            Client = client;
            Serializer = serializer;
            Headers = headers;
            DefaultEncoding = encoding;
        }

        public ObjectClient(IClient client, IFormatSerializer serializer, IEnumerable<RequestHeader> headers)
            : this(client, serializer, headers, Encoding.UTF8) { }

        public IClient Client { get; private set; }

        public IFormatSerializer Serializer { get; private set; }

        public IEnumerable<RequestHeader> Headers { get; private set; }

        public Encoding DefaultEncoding { get; private set; }

        public async Task<ObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var response = await Client.GetAsync(uri, Headers);
            return Deserialize<TResponse>(response);
        }

        public async Task<ObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PostAsync(uri, content, Headers);
            return Deserialize<TResponse>(response);
        }

        public Task<ClientResponse> PostNoResponseAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PostAsync(uri, content, Headers);
        }

        public async Task<ObjectClientResponse<TResponse>> PostAsync<TResponse>(string uri)
        {
            var response = await Client.PostAsync(uri, null, Headers);
            return Deserialize<TResponse>(response);
        }

        public async Task<ObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PutAsync(uri, content, Headers);
            return Deserialize<TResponse>(response);
        }

        public Task<ClientResponse> PutNoResponseAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PutAsync(uri, content, Headers);
        }

        public async Task<ObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var response = await Client.DeleteAsync(uri, Headers);
            return Deserialize<TResponse>(response);
        }

        #region Helper

        private string Serialize<T>(T data)
        {
            return Serializer.Serialize(data);
        }

        private ObjectClientResponse<T> Deserialize<T>(ClientResponse response)
        {
            var contentString = response.ContentString;
            var content = Serializer.Deserialize<T>(contentString);
            var problemDetails = DeserializeProblemDetails(contentString);

            return new ObjectClientResponse<T>(response, content, problemDetails);
        }

        private IProblemDetails DeserializeProblemDetails(string contentString)
        {
            try
            {
                return Serializer.Deserialize<ProblemDetailsResponse>(contentString);
            }
            catch (Exception)
            {
                // TODO: https://github.com/optivem/framework-dotnetcore/issues/273
                return null;
            }
        }

        #endregion Helper
    }
}