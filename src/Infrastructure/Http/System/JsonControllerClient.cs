using Optivem.Common.Http;
using Optivem.Common.Serialization;

namespace Optivem.Infrastructure.Http.System
{
    public class JsonControllerClient : ControllerClient
    {
        public JsonControllerClient(IClient client, IJsonSerializationService serializationService, string controllerPath)
            : base(client, new JsonClient(client, serializationService), controllerPath)
        {
        }
    }
}