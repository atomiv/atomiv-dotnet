using Newtonsoft.Json;
using Optivem.Platform.Core.Common.RestClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default
{
    public class RestControllerClient : IRestControllerClient
    {
        private readonly string _path;
        private readonly HttpClient _client;
        
        public RestControllerClient(string path)
        {
            _path = path;
            _client = new HttpClient();
        }
        
        public async Task<T> GetAsync<T>(int id)
        {
            var requestUri = $"{_path}/{id}";
            using (var response = await _client.GetAsync(requestUri))
            {
                EnsureSuccess(response);

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
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
