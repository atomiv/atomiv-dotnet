using Optivem.Common.Serialization;
using System.Net.Http;

namespace Optivem.Infrastructure.Http.System
{
    public class RestServiceClient
    {
        public RestServiceClient(ISerializationService serializationService, HttpClient client)
        {
            SerializationService = serializationService;
            Client = client;
        }

        public ISerializationService SerializationService { get; private set; }
        public HttpClient Client { get; private set; }
    }
}
