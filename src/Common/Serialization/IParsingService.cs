namespace Optivem.Common.Serialization
{
    public interface IParsingService
    {
        T Parse<T>(string value);
    }
}
