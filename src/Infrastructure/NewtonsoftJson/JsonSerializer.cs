using Newtonsoft.Json;
using Optivem.Framework.Core.Common.Serialization;
using System;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.NewtonsoftJson
{
    public class JsonSerializer : IJsonSerializer
    {
        // TODO: VC: Consider JsonSerializer
        // private readonly JsonSerializer _serializer;

        public JsonSerializer()
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