using Optivem.Common.Http;
using Optivem.Common.Serialization;

namespace Optivem.Infrastructure.Http.System
{
    public class ValidatedJsonControllerClient : ControllerClient
    {
        public ValidatedJsonControllerClient(IClient client, IJsonSerializationService serializationService, string controllerUri)
            : base(client, new ValidatedObjectClient(new JsonClient(client, serializationService), serializationService), controllerUri)
        {
        }
    }
}