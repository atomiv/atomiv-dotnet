using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class FindHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        : BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        where TRequest : IIdentifiableCommand<TKey, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var entity = await Repository.GetSingleOrDefaultAsync(id);
            var response = Mapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }

    public class FindHandler<TKey, TEntity, TRequest, TResponse>
        : FindHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest, TResponse>
        where TRequest : IIdentifiableCommand<TKey, TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public FindHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
