using Microsoft.Extensions.Options;
using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;
using Optivem.Framework.Infrastructure.AspNetCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Optivem.Template.Web.UI
{
    public class ApiClient : WebClient
    {
        public ApiClient(IOptions<ApiClientOptions> options) : base(Create(options))
        {
        }

        private static HttpClient Create(IOptions<ApiClientOptions> options)
        {
            var url = new Uri(options.Value.Url);

            return new HttpClient()
            {
                BaseAddress = url,
            };
        }
    }
}
