using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Http.System
{
    public class ObjectClient : IObjectClient
    {
        // TODO: Boolean if include problem details

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

        public async Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>(string uri)
        {
            var response = await Client.GetAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> GetAsync(string uri)
        {
            return Client.GetAsync(uri);
        }
        public Task<IObjectClientResponse<TResponse>> GetAsync<TResponse>()
        {
            throw new NotImplementedException();
        }

        public Task<IClientResponse> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PostAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> PostAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PostAsync(uri, content, ContentType);
        }
        public Task<IObjectClientResponse<TResponse>> PostAsync<TRequest, TResponse>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IClientResponse> PostAsync<TRequest>(TRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IObjectClientResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
        {
            var content = Serialize(request);
            var response = await Client.PutAsync(uri, content, ContentType, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> PutAsync<TRequest>(string uri, TRequest request)
        {
            var content = Serialize(request);
            return Client.PutAsync(uri, content, ContentType);
        }

        public async Task<IObjectClientResponse<TResponse>> DeleteAsync<TResponse>(string uri)
        {
            var response = await Client.DeleteAsync(uri, AcceptType);
            return Deserialize<TResponse>(response);
        }

        public Task<IClientResponse> DeleteAsync(string uri)
        {
            return Client.DeleteAsync(uri);
        }

        #region Helper

        private string Serialize<T>(T data)
        {
            return SerializationService.Serialize(data);
        }

        private IObjectClientResponse<T> Deserialize<T>(IClientResponse response)
        {
            var contentString = response.ContentString;
            var content = SerializationService.Deserialize<T>(contentString);
            var problemDetails = DeserializeProblemDetails(contentString);
            
            return new ObjectClientResponse<T>(response, content, problemDetails);
        }

        private IProblemDetails DeserializeProblemDetails(string contentString)
        {
            try
            {
                return SerializationService.Deserialize<ProblemDetailsResponse>(contentString);
            }
            catch(Exception)
            {
                return null;
                // TODO: VC: Handle deserialization error, or perhaps throw?
            }
        }



        #endregion Helper
    }
}