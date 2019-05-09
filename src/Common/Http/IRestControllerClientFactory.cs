namespace Optivem.Common.Http
{
    public interface IRestControllerClientFactory
    {
        T Create<T>(string uri);
    }
}
