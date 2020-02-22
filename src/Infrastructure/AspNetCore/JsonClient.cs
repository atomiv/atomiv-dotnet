using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;
using System.Collections.Generic;
using System.Net;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class JsonClient : ObjectClient
    {
        private const string MediaType = "application/json";

        private static IEnumerable<RequestHeader> DefaultHeaders = new List<RequestHeader>
        {
            new RequestHeader(HttpRequestHeader.Accept.ToString(), MediaType),
            new RequestHeader(HttpRequestHeader.ContentType.ToString(), MediaType),
        };

        public JsonClient(IClient client, IJsonSerializer serializer, IEnumerable<RequestHeader> headers)
            : base(client, serializer, headers)
        {
        }

        public JsonClient(IClient client, IJsonSerializer serializer)
            : this(client, serializer, DefaultHeaders)
        {
        }
    }
}