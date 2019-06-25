using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class JsonControllerClient : ControllerClient
    {
        public JsonControllerClient(IClient client, IJsonSerializationService serializationService, string controllerPath)
            : base(client, new JsonClient(client, serializationService), controllerPath)
        {
        }
    }
}