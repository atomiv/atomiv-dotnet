using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default
{
    // TODO: VC: This is for json, consider other types, e.g. content xml, csv, etc

    public class RestControllerClient<TId,
        TGetCollectionResponse, TGetResponse,
        TPostRequest, TPostResponse,
        TPutRequest, TPutResponse,
        TPatchRequest, TPatchResponse> 
        : IRestControllerClient<TId,
            TGetCollectionResponse, TGetResponse,
            TPostRequest, TPostResponse,
            TPutRequest, TPutResponse,
            TPatchRequest, TPatchResponse>
    {
        private readonly HttpClient _client;
        private readonly string _controllerPath;
        private readonly ISerializationService _jsonSerializationService;

        public RestControllerClient(HttpClient client, string controllerPath, ISerializationService jsonSerializationService)
        {
            _client = client;
            _controllerPath = controllerPath;
            _jsonSerializationService = jsonSerializationService;
        }

        public async Task<TGetCollectionResponse> GetAsync()
        {
            var requestUri = GetRequestPath();
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TGetCollectionResponse>(responseString);
            }
        }

        public async Task<TGetResponse> GetAsync(TId id)
        {
            var requestUri = GetRequestPathById(id);
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TGetResponse>(responseString);
            }
        }

        public async Task<TPostResponse> PostAsync(TPostRequest request)
        {
            var requestUri = GetRequestPath();
            var requestContent = CreateContent(request);

            using (var response = await _client.PostAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TPostResponse>(responseString);
            }
        }

        public async Task<TPutResponse> PutAsync(TId id, TPutRequest request)
        {
            var requestUri = GetRequestPathById(id);
            var requestContent = CreateContent(request);

            using (var response = await _client.PutAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TPutResponse>(responseString);
            }
        }

        public async Task<TPatchResponse> PatchAsync(TId id, TPatchRequest request)
        {
            var requestUri = GetRequestPathById(id);
            var requestContent = CreateContent(request);

            using (var response = await _client.PatchAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TPatchResponse>(responseString);
            }
        }

        public async Task DeleteAsync(TId id)
        {
            var requestUri = GetRequestPathById(id);

            using (var response = await _client.DeleteAsync(requestUri))
            {
                EnsureSuccess(response);
            }
        }

        private string GetRequestPath()
        {
            return _controllerPath;
        }

        private string GetRequestPathById(TId id)
        {
            return $"{_controllerPath}/{id}";
        }

        public void Dispose()
        {
            // No actions
        }

        private void EnsureSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var statusCode = response.StatusCode;
                var content = response.Content.ToString();

                throw new RestClientException(statusCode, content);
            }
        }

        private StringContent CreateContent<T>(T request)
        {
            var requestString = _jsonSerializationService.Serialize(request);
            var requestContent = new StringContent(requestString, Encoding.UTF8, "application/json");
            return requestContent;
        }


    }

    public class RestControllerClient<TId, TRequest, TResponse>
        : RestControllerClient<TId,
            List<TResponse>, TResponse,
            TRequest, TResponse,
            TRequest, TResponse,
            TRequest, TResponse>,
        IRestControllerClient<TId,
            List<TResponse>, TResponse,
            TRequest, TResponse,
            TRequest, TResponse,
            TRequest, TResponse>
    {
        public RestControllerClient(HttpClient client, string controllerPath, ISerializationService jsonSerializationService) 
            : base(client, controllerPath, jsonSerializationService)
        {
        }
    }

    public class RestControllerClient<TId, TDto>
            : RestControllerClient<TId, TDto, TDto>,
            IRestControllerClient<TId, TDto>
    {
        public RestControllerClient(HttpClient client, string controllerPath, ISerializationService jsonSerializationService)
            : base(client, controllerPath, jsonSerializationService)
        {
        }
    }
}
