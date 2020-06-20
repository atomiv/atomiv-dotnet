using System;
using System.Collections.Generic;

namespace Atomiv.Core.Common.Serialization
{
    public interface IFormatSerializer
    {
        string Serialize<T>(T data);

        string Serialize(object data, Type type);

        T Deserialize<T>(string data);

        object Deserialize(string data, Type type);

        string SerializeEnumerable<E>(IEnumerable<E> data);

        IEnumerable<E> DeserializeEnumerable<E>(string data);
    }
}