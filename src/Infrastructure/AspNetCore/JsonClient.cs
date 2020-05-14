using Microsoft.Extensions.Primitives;
using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using System.Net;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class JsonClient : ObjectClient
    {
        private const string MediaType = "application/json";

        private static HeaderDictionary DefaultHeaders = new HeaderDictionary
        (
            (HttpRequestHeader.Accept.ToString(), new StringValues(MediaType)),
            (HttpRequestHeader.ContentType.ToString(), new StringValues(MediaType))
        );

        public JsonClient(IClient client, IJsonSerializer serializer, HeaderDictionary headers)
            : base(client, serializer, headers)
        {
        }

        public JsonClient(IClient client, IJsonSerializer serializer)
            : this(client, serializer, DefaultHeaders)
        {
        }
    }
}