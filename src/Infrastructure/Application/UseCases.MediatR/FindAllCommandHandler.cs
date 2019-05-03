using Optivem.Framework.Core.Application.Ports.Out.Mappers;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Ports.Out.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public class FindAllCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TResponse>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, object, IEnumerable<TResponse>>
        where TCommand : ICommand<object, IEnumerable<TResponse>>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(requestMapper, responseMapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<IEnumerable<TResponse>> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var entities = await Repository.GetAsync();
            var responses = ResponseMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
            return responses;
        }
    }

    public class FindAllCommandHandler<TKey, TEntity, TCommand, TResponse>
        : FindAllCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TResponse>
        where TCommand : ICommand<object, IEnumerable<TResponse>>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork)
            : base(requestMapper, responseMapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
