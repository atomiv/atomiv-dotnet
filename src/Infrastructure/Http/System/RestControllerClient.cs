using Microsoft.AspNetCore.Mvc;
using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Common.RestClient.Default
{
    // TODO: VC: This is for json, consider other types, e.g. content xml, csv, etc

    public class RestControllerClient<TId,
        TGetCollectionResponse, 
        TGetResponse,
        TPostRequest, TPostResponse,
        TPutRequest, TPutResponse> 
        : IRestControllerClient<TId,
            TGetCollectionResponse, TGetResponse,
            TPostRequest, TPostResponse,
            TPutRequest, TPutResponse>
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

        public async Task<IEnumerable<TGetCollectionResponse>> GetCollectionAsync()
        {
            var requestUri = GetRelativePath();
            using (var response = await _client.GetAsync(requestUri))
            {
                await EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<IEnumerable<TGetCollectionResponse>>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task<string> GetAsync(string uri, string accept)
        {
            var requestUri = GetAbsolutePath(uri);

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
                await EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        public async Task<TGetResponse> GetAsync(TId id)
        {
            var requestUri = GetRelativePathById(id);
            using (var response = await _client.GetAsync(requestUri))
            {
                await EnsureSuccess(response);

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
                await EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TPostResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task<string> PostAsync(string uri, string request, string contentType)
        {
            var requestUri = GetAbsolutePath(uri);
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
                await EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }

        public async Task<TPutResponse> PutAsync(TId id, TPutRequest request)
        {
            var requestUri = GetRelativePathById(id);
            var requestContent = CreateContent(request);

            using (var response = await _client.PutAsync(requestUri, requestContent))
            {
                await EnsureSuccess(response);

                var responseString = await response.Content.ReadAsStringAsync();
                return _serializationService.Deserialize<TPutResponse>(responseString, SerializationFormatType.Json);
            }
        }

        public async Task DeleteAsync(TId id)
        {
            var requestUri = GetRelativePathById(id);

            using (var response = await _client.DeleteAsync(requestUri))
            {
                await EnsureSuccess(response);
            }
        }

        private Uri GetAbsolutePath(string uri)
        {
            var relativePath = GetRelativePath(uri);
            return new Uri(_client.BaseAddress, relativePath);
        }

        private string GetRelativePath(string uri = null)
        {
            if(uri == null)
            {
                return _controllerPath;
            }
            else
            {
                return $"{_controllerPath}/{uri}";
            }

        }

        private string GetRelativePathById(TId id)
        {
            return $"{_controllerPath}/{id}";
        }

        public void Dispose()
        {
            // No actions
        }

        private async Task EnsureSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var statusCode = response.StatusCode;
                var content = await response.Content.ReadAsStringAsync();

                // TODO: VC: Also perhaps including content type in exception, so that client can do custom deserialization
                // or pass in func for handling errors which will do the deserialization, therefore supporting not just problem details
                // but instead others too? also, throwing exception vs returning object?

                var problemDetails = GetProblemDetails(content);

                throw new RestClientException(statusCode, content, problemDetails);
            }
        }

        private IProblemDetails GetProblemDetails(string content)
        {
            // TODO: VC: Handling problem details in various formats, not just json
            // TODO: VC: check if this works for API without problem details, but something else... otherwise null

            var problemDetails = _serializationService.Deserialize<ProblemDetails>(content, SerializationFormatType.Json);
            return new ProblemDetailsWrapper(problemDetails);
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
            TResponse, 
            TResponse,
            TRequest, TResponse,
            TRequest, TResponse>,
        IRestControllerClient<TId,
            TResponse, 
            TResponse,
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
