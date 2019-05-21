using Optivem.Core.Domain;

namespace Optivem.Core.Application
{
    public interface IRequestMapper<TRequest, TEntity>
        where TRequest : IRequest
        where TEntity : IEntity
    {
        TEntity Map(TRequest request);
    }

    public interface IRequestMapper
    {
        TEntity Map<TRequest, TEntity>(TRequest request)
            where TRequest : IRequest
            where TEntity : IEntity;
    }
}