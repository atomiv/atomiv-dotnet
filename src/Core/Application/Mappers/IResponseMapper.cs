namespace Optivem.Core.Application
{
    public interface IResponseMapper<TEntity, TResponse>
    {
        TResponse Map(TEntity entity);
    }

    public interface IResponseMapper
    {
        TResponse Map<TEntity, TResponse>(TEntity entity);
    }
}
