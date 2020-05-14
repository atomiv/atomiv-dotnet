using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ObjectClient : IObjectClient
    {
        public ObjectClient(IClient client, IFormatSerializer serializer, HeaderDictionary headers, Encoding encoding)
        {
            Client = client;
            Serializer = serializer;
            Headers = headers;
            Encoding = encoding;
        }

        public ObjectClient(IClient client, IFormatSerializer serializer, HeaderDictionary headers)
            : this(client, serializer, headers, Encoding.UTF8) { }

        public IClient Client { get; }

        public IFormatSerializer Serializer { get; }

        public HeaderDictionary Headers { get; }

        public Encoding Encoding { get; }

        public async Task<ObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri, HeaderDictionary headers = null)
        {
            var headerUnion = Union(headers);
            var response = await Client.GetAsync(uri, headerUnion);
            return Deserialize<TResponse>(response);
        }

        public async Task<ObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            var content = Serialize(request);
            var headerUnion = Union(headers);
            var response = await Client.PostAsync(uri, content, headerUnion);
            return Deserialize<TResponse>(response);
        }

        public Task<ClientResponse> PostNoResponseAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            var content = Serialize(request);
            var headerUnion = Union(headers);
            return Client.PostAsync(uri, content, headerUnion);
        }

        public async Task<ObjectClientResponse<TResponse>> PostAsync<TResponse>(string uri, HeaderDictionary headers = null)
        {
            var headerUnion = Union(headers);
            var response = await Client.PostAsync(uri, null, headerUnion);
            return Deserialize<TResponse>(response);
        }

        public async Task<ObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            var content = Serialize(request);
            var headerUnion = Union(headers);
            var response = await Client.PutAsync(uri, content, headerUnion);
            return Deserialize<TResponse>(response);
        }

        public Task<ClientResponse> PutNoResponseAsync<TRequest>(string uri, TRequest request, HeaderDictionary headers = null)
        {
            var content = Serialize(request);
            var headerUnion = Union(headers);
            return Client.PutAsync(uri, content, headerUnion);
        }

        public async Task<ObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri, HeaderDictionary headers = null)
        {
            var headerUnion = Union(headers);
            var response = await Client.DeleteAsync(uri, headerUnion);
            return Deserialize<TResponse>(response);
        }

        #region Helper

        private HeaderDictionary Union(HeaderDictionary other)
        {
            if(other == null)
            {
                return Headers;
            }

            return Headers.Union(other);
        }

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