namespace Optivem.Core.Application
{
    // TODO: VC: DELETE


    /*
    public interface IResponseMapper<TEntity, TResponse>
        where TEntity : IEntity
        where TResponse : IResponse
    {
        TResponse Map(TEntity entity);
    }

    public interface IResponseMapper
    {
        TResponse Map<TEntity, TResponse>(TEntity entity)
            where TEntity : IEntity
            where TResponse : IResponse;

        IEnumerable<TResponse> MapEnumerable<TEntity, TResponse>(IEnumerable<TEntity> entities)
            where TEntity : IEntity
            where TResponse : IResponse;
    }

    */

    public interface IResponseMapper
    {
        TResponse Map<T, TResponse>(T obj) where TResponse : IResponse;
    }

    public interface IResponseMapper<T, TResponse>
        where TResponse : IResponse
    {
        TResponse Map(T obj);
    }

    // TODO: VC: Implement these mappers and do early testing that they exist
}