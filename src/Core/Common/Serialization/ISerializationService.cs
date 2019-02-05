using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.Serialization
{
    public interface ISerializationService
    {
        string Serialize<T>(T data, SerializationFormatType format);

        T Deserialize<T>(string data, SerializationFormatType format);
    }
}
