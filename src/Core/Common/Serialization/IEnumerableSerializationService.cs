using System;
using System.Collections.Generic;

namespace Optivem.Platform.Core.Common.Serialization
{
    public interface IEnumerableSerializationService
    {
        string Serialize<T>(IEnumerable<T> records);

        string Serialize(IEnumerable<object> records, Type recordType);

        IEnumerable<T> Deserialize<T>(string records);

        IEnumerable<object> Deserialize(string records, Type recordType);
    }
}