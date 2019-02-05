using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
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
        private readonly ISerializationService _serializationService;

        public RestControllerClient(HttpClient client, string controllerPath, 
            ISerializationService serializationService)
        {
            _client = client;
            _controllerPath = controllerPath;
            _serializationService = serializationService;
        }

        public async Task<TGetCollectionResponse> GetCollectionAsync()
        {
            var requestUri = GetRelativePath();
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TGetCollectionResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task<string> GetCollectionAsync(string accept)
        {
            var requestUri = GetAbsolutePath();

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = requestUri,
                Headers =
                {
                    { HttpRequestHeader.Accept.ToString(), accept }
                },
            };

            using (var response = await _client.SendAsync(requestMessage))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        public async Task<TGetResponse> GetAsync(TId id)
        {
            var requestUri = GetRelativePathById(id);
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TGetResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task<TPostResponse> PostAsync(TPostRequest request)
        {
            var requestUri = GetRelativePath();
            var requestContent = CreateContent(request);

            using (var response = await _client.PostAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TPostResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task PostCollectionAsync(string request, string contentType)
        {
            var requestUri = GetAbsolutePath();
            var content = CreateContent(request, contentType);

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = requestUri,
                Headers =
                {
                    { HttpRequestHeader.ContentType.ToString(), contentType }
                },
                Content = content,
            };

            using (var response = await _client.SendAsync(requestMessage))
            {
                EnsureSuccess(response);
            }
        }

        public async Task<TPutResponse> PutAsync(TId id, TPutRequest request)
        {
            var requestUri = GetRelativePathById(id);
            var requestContent = CreateContent(request);

            using (var response = await _client.PutAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TPutResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task<TPatchResponse> PatchAsync(TId id, TPatchRequest request)
        {
            var requestUri = GetRelativePathById(id);
            var requestContent = CreateContent(request);

            using (var response = await _client.PatchAsync(requestUri, requestContent))
            {
                EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TPatchResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task DeleteAsync(TId id)
        {
            var requestUri = GetRelativePathById(id);

            using (var response = await _client.DeleteAsync(requestUri))
            {
                EnsureSuccess(response);
            }
        }

        private Uri GetAbsolutePath()
        {
            var relativePath = GetRelativePath();
            return new Uri(_client.BaseAddress, relativePath);
        }

        private string GetRelativePath()
        {
            return _controllerPath;
        }

        private string GetRelativePathById(TId id)
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

        private StringContent CreateContent(string content, string contentType)
        {
            var requestContent = new StringContent(content, Encoding.UTF8, contentType);
            return requestContent;
        }

        private StringContent CreateContent<T>(T request)
        {
            var content = _serializationService.Serialize(request, SerializationFormatType.Json);
            return CreateContent(content, "application/json");
        }



        public Task PutCollectionAsync(string request, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task PatchCollectionAsync(string request, string contentType)
        {
            throw new NotImplementedException();
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
        public RestControllerClient(HttpClient client, string controllerPath, ISerializationService serializationService) 
            : base(client, controllerPath, serializationService)
        {
        }
    }

    public class RestControllerClient<TId, TDto>
            : RestControllerClient<TId, TDto, TDto>,
            IRestControllerClient<TId, TDto>
    {
        public RestControllerClient(HttpClient client, string controllerPath, ISerializationService serializationService)
            : base(client, controllerPath, serializationService)
        {
        }
    }
}
