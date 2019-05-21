namespace Optivem.Common.Serialization
{
    public interface ISerializationService
    {
        string Serialize<T>(T data, SerializationFormatType format);

        T Deserialize<T>(string data, SerializationFormatType format);
    }
}