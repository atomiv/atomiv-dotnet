using Optivem.Core.Application.Requests;
using Optivem.Core.Domain.Entities;

namespace Optivem.Core.Application.Mappers
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