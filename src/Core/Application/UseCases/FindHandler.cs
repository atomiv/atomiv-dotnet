using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class FindHandler<TUnitOfWork, TRepository, TRequest, TResponse, TEntity, TKey>
        : BaseHandler<TUnitOfWork, TRepository, TRequest, TResponse, TEntity, TKey>
        where TRequest : IIdentifiableRequest<TResponse, TKey>
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
}
