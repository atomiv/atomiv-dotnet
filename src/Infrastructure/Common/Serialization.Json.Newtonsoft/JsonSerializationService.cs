using Newtonsoft.Json;
using Optivem.Platform.Core.Common.Serialization;

namespace Optivem.Platform.Infrastructure.Common.Serialization.Json.NewtonsoftJson
{
    public class JsonSerializationService : ISerializationService
    {
        // TODO: VC: Consider JsonSerializer
        // private readonly JsonSerializer _serializer;

        public JsonSerializationService()
        {

        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
