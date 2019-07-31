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
        // TODO: VC: make configurable, e.g. pass via configuration service to this constructor
        private const string Url = "https://localhost:44315/api";

        public ApiClient() : base(Create())
        {
        }

        private static HttpClient Create()
        {
            return new HttpClient()
            {
                BaseAddress = new Uri(Url),
            };
        }
    }
}
