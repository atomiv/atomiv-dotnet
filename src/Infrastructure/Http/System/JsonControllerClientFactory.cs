using Optivem.Common.Http;
using Optivem.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Http.System
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
