namespace Atomiv.Core.Common.Serialization
{
    public interface IParser
    {
        object Parse(string value);

        T Parse<T>(string value);
    }

    public interface IParser<T>
    {
        T Parse(string value);
    }
}