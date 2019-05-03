namespace Optivem.Framework.Core.Application.Mappers
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
