using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class FindAllCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TResponse>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, object, IEnumerable<TResponse>>
        where TCommand : ICommand<object, IEnumerable<TResponse>>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllCommandHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<IEnumerable<TResponse>> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var entities = await Repository.GetAsync();
            var responses = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
            return responses;
        }
    }

    public class FindAllCommandHandler<TKey, TEntity, TCommand, TResponse>
        : FindAllCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TResponse>
        where TCommand : ICommand<object, IEnumerable<TResponse>>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
