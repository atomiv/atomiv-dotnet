namespace Optivem.Atomiv.Core.Common.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T data, FormatType format);

        T Deserialize<T>(string data, FormatType format);
    }
}