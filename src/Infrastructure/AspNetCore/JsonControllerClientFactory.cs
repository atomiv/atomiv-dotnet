using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Reflection;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class JsonControllerClientFactory : IControllerClientFactory
    {
        public JsonControllerClientFactory(IClient client, IJsonSerializationService serializationService, IPropertyMapper propertyFactory)
        {
            Client = client;
            SerializationService = serializationService;
            PropertyFactory = propertyFactory;
        }

        public IClient Client { get; }

        public IJsonSerializationService SerializationService { get; }

        public IPropertyMapper PropertyFactory { get; }

        public IControllerClient Create(string controllerUri)
        {
            return new JsonControllerClient(Client, SerializationService, PropertyFactory, controllerUri);
        }
    }
}