using Atomiv.Core.Common.Http;
using Atomiv.Core.Common.Reflection;
using Atomiv.Core.Common.Serialization;

namespace Atomiv.Infrastructure.AspNetCore
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