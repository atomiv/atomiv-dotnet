using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class JsonControllerClientFactory : IControllerClientFactory
    {
        public JsonControllerClientFactory(IClient client, IJsonSerializationService serializationService)
        {
            Client = client;
            SerializationService = serializationService;
        }

        public IClient Client { get; private set; }

        public IJsonSerializationService SerializationService { get; private set; }

        public IControllerClient Create(string controllerUri)
        {
            return new JsonControllerClient(Client, SerializationService, controllerUri);
        }
    }
}