namespace Optivem.Core.Common.Serialization
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}