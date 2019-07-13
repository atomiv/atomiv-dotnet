namespace Optivem.Framework.Core.Application
{
    public interface IResponseMapper
    {
        TResponse Map<T, TResponse>(T obj) where TResponse : IResponse;
    }

    public interface IResponseMapper<T, TResponse>
        where TResponse : IResponse
    {
        TResponse Map(T obj);
    }
}