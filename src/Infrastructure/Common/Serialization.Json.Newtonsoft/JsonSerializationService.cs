using Newtonsoft.Json;
using Optivem.Platform.Core.Common.Serialization;

namespace Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson
{
    public class JsonSerializationService : IJsonSerializationService
    {
        // TODO: VC: Consider JsonSerializer
        // private readonly JsonSerializer _serializer;

        public JsonSerializationService()
        {

        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
