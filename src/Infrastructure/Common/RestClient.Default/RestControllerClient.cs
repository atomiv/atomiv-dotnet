using Optivem.Platform.Core.Common.RestClient;
using Optivem.Platform.Core.Common.Serialization.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default
{
    public class RestControllerClient : IRestControllerClient
    {
        private readonly string _path;
        private readonly IJsonSerializationService _jsonSerializationService;
        private readonly HttpClient _client;
        
        public RestControllerClient(string path, IJsonSerializationService jsonSerializationService)
        {
            _path = path;
            _jsonSerializationService = jsonSerializationService;
            _client = new HttpClient();
        }
        
        public async Task<T> GetAsync<T>(int id)
        {
            var requestUri = $"{_path}/{id}";
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var content = await response.Content.ReadAsStringAsync();
                return _jsonSerializationService.Deserialize<T>(content);
            }
        }

        // TODO: VC: Remove dependency on Newtonsoft.Json

        public void Dispose()
        {
            _client.Dispose();
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
