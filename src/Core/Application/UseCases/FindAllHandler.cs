using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class FindAllHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        : BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, IEnumerable<TResponse>>
        where TRequest : IIdentifiableRequest<IEnumerable<TResponse>, TKey>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<IEnumerable<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entities = await Repository.GetAsync();
            var responses = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
            return responses;
        }
    }

    public class FindAllHandler<TKey, TEntity, TRequest, TResponse>
        : FindAllHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest, TResponse>
        where TRequest : IIdentifiableRequest<IEnumerable<TResponse>, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
