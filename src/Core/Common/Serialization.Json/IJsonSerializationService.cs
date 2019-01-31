namespace Optivem.Platform.Core.Common.Serialization.Json
{
    public interface IJsonSerializationService
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string content);
    }
}
