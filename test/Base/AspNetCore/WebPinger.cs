using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebPinger
    {
        public async Task<WebPingResponse> PingAsync(Uri uri)
        {
            // TODO: VC: Use component

            try
            {
                using (var client = CreateHttpClient(uri))
                {
                    var response = await client.GetAsync("");

                    var success = response.IsSuccessStatusCode;
                    var code = response.StatusCode;
                    var content = await response.Content.ReadAsStringAsync();

                    return new WebPingResponse(success, code, content);
                }
            }
            catch(Exception ex)
            {
                var message = ex.ToString();
                return new WebPingResponse(false, 0, message);
            }
        }

        public Task<WebPingResponse> PingAsync(string baseUrl, string relativePath)
        {
            var baseUri = new Uri(baseUrl);
            var uri = new Uri(baseUri, relativePath);
            return PingAsync(uri);
        }

        private HttpClient CreateHttpClient(Uri uri)
        {
            var baseAddress = uri;

            return new HttpClient
            {
                BaseAddress = baseAddress,
            };
        }
    }
}
