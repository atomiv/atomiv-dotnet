using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Core.Common.Serialization;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class JsonClient : ObjectClient
    {
        private const string MediaType = "application/json";

        public JsonClient(IClient client, IJsonSerializer serializer)
            : base(client, serializer, MediaType, MediaType)
        {
        }
    }
}