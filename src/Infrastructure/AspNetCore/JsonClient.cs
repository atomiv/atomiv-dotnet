using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
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