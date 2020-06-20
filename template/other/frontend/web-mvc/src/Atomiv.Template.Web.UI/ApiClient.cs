using Microsoft.Extensions.Options;
using Atomiv.Infrastructure.AspNetCore;
using System;
using System.Net.Http;

namespace Atomiv.Template.Web.UI
{
    public class ApiClient : WebClient
    {
        public ApiClient(IOptions<ApiClientOptions> options) : base(Create(options))
        {
        }

        private static HttpClient Create(IOptions<ApiClientOptions> options)
        {
            var url = options.Value.Url;
            var baseAddress = new Uri(url);

            return new HttpClient()
            {
                BaseAddress = baseAddress,
            };
        }
    }
}