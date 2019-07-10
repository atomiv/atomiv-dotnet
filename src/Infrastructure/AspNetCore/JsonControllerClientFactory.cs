using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Core.Common.Reflection;
using Optivem.Framework.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class JsonControllerClientFactory : IControllerClientFactory
    {
        public JsonControllerClientFactory(IClient client, IJsonSerializer serializer, IPropertyMapper propertyFactory)
        {
            Client = client;
            Serializer = serializer;
            PropertyFactory = propertyFactory;
        }

        public IClient Client { get; }

        public IJsonSerializer Serializer { get; }

        public IPropertyMapper PropertyFactory { get; }

        public IControllerClient Create(string controllerUri)
        {
            return new JsonControllerClient(Client, Serializer, PropertyFactory, controllerUri);
        }
    }
}