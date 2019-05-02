using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class FindAllHandler<TUnitOfWork, TRepository, TRequest, TResponse, TEntity, TKey>
        : BaseHandler<TUnitOfWork, TRepository, TRequest, IEnumerable<TResponse>, TEntity, TKey>
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
}
