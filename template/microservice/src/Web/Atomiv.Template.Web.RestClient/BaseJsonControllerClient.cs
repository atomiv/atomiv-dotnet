using Microsoft.Net.Http.Headers;
using Atomiv.Core.Common.Http;
using Atomiv.Core.Common.Serialization;
using Atomiv.Infrastructure.AspNetCore;
using Atomiv.Template.Web.RestClient.Interface;
using System.Net.Http;

namespace Atomiv.Template.Web.RestClient
{
    public class BaseJsonControllerClient
    {
        public BaseJsonControllerClient(HttpClient httpClient, IJsonSerializer jsonSerializer, string controllerUri)
        {
            Client = new JsonHttpControllerClient(httpClient, jsonSerializer, controllerUri);
        }

        protected JsonHttpControllerClient Client { get; }

        protected HeaderDictionary GetHeaders(HeaderData headerData)
        {
            return new HeaderDictionary(
                (HeaderNames.Authorization, $"Bearer {headerData.Token}"),
                (HeaderNames.AcceptLanguage, headerData.Language));
        }
    }
}
