using AutoMapper;
using MediatR;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class CreateHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse> 
        : BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public CreateHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever) 
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TRequest, TEntity>(request);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            var response = Mapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }

    public class CreateHandler<TKey, TEntity, TRequest, TResponse>
        : CreateHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public CreateHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
