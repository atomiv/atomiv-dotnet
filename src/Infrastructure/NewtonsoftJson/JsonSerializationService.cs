using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Optivem.Core.Common.Serialization;

namespace Optivem.Framework.Infrastructure.Common.Serialization.Json.NewtonsoftJson
{
    public class JsonSerializationService : IJsonSerializationService
    {
        // TODO: VC: Consider JsonSerializer
        // private readonly JsonSerializer _serializer;

        public JsonSerializationService()
        {

        }

        public string Serialize(object data, Type type)
        {
            return JsonConvert.SerializeObject(data, type, Formatting.Indented, null);
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
        
        public object Deserialize(string data, Type type)
        {
            return JsonConvert.DeserializeObject(data, type);
        }

        public string SerializeEnumerable<E>(IEnumerable<E> data)
        {
            return Serialize(data);
        }

        public IEnumerable<E> DeserializeEnumerable<E>(string data)
        {
            return Deserialize<IEnumerable<E>>(data);
        }
    }
}
