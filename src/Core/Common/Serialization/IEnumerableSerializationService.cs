using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.Serialization
{
    public interface IEnumerableSerializationService
    {
        string Serialize<T>(IEnumerable<T> records);

        IEnumerable<T> Deserialize<T>(IEnumerable<string> records);

        IEnumerable<T> Deserialize<T>(string records);
    }
}
