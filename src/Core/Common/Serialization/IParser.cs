namespace Optivem.Framework.Core.Common.Serialization
{
    public interface IParser
    {
        object Parse(string value);
    }

    public interface IParser<T>
    {
        T Parse(string value);
    }
}