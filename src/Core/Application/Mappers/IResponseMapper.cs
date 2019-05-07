using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;
using System.Collections.Generic;

namespace Optivem.Core.Application.Mappers
{
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
}
