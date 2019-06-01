using Optivem.Core.Common.Http;
using Optivem.Core.Common.Serialization;

namespace Optivem.Infrastructure.AspNetCore
{
    public class JsonClient : ObjectClient
    {
        private const string MediaType = "application/json";

        public JsonClient(IClient client, IJsonSerializationService serializationService)
            : base(client, serializationService, MediaType, MediaType)
        {
        }
    }
}