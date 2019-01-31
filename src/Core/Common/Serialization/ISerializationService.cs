namespace Optivem.Platform.Core.Common.Serialization
{
    public interface ISerializationService
    {
        string Serialize<T>(T obj);

        T Deserialize<T>(string content);
    }
}
