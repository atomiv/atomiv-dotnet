using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
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