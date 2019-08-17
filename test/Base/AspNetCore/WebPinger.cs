using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebPinger
    {
        public async Task<bool> PingAsync(Uri uri)
        {
            // TODO: VC: Use component

            try
            {
                using (var client = CreateHttpClient(uri))
                {
                    var response = await client.GetAsync("");

                    return response.IsSuccessStatusCode;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Task<bool> PingAsync(string baseUrl, string relativePath)
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
