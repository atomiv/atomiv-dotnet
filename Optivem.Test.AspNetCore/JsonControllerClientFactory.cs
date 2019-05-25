using Optivem.Common.Http;
using Optivem.Infrastructure.Serialization.Json.NewtonsoftJson;

namespace Optivem.Test.AspNetCore
{
    public class JsonControllerClientFactory : IControllerClientFactory
    {
        private readonly IControllerClientFactory _factory;

        public JsonControllerClientFactory(IClient client)
        {
            Client = client;
            _factory = CreateControllerClientFactory(client);
        }

        public IClient Client { get; private set; }

        public IControllerClient Create(string controllerUri)
        {
            return _factory.Create(controllerUri);
        }

        private static IControllerClientFactory CreateControllerClientFactory(IClient client)
        {
            var serializationService = new JsonSerializationService();
            return new Infrastructure.Http.System.JsonControllerClientFactory(client, serializationService);
        }
    }
}
