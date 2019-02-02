using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default
{
    public class RestControllerClient<TId> : IRestControllerClient<TId>
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

        public async Task<TResponse> GetResourcesAsync<TResponse>()
        {
            var requestUri = GetRequestPath();
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var content = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TResponse>(content);
            }
        }

        public async Task<TResponse> GetResourceAsync<TResponse>(TId id)
        {
            var requestUri = GetRequestPathById(id);
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var content = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<TResponse>(content);
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

    }
}
