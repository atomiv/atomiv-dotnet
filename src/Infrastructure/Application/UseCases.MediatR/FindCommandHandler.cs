using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public class FindCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TResponse>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TKey, TResponse>
        where TCommand : ICommand<TKey, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public FindCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(requestMapper, responseMapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var id = command.Request;
            var entity = await Repository.GetSingleOrDefaultAsync(id);
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }

    public class FindCommandHandler<TKey, TEntity, TCommand, TResponse>
        : FindCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TResponse>
        where TCommand : ICommand<TKey, TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public FindCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork)
            : base(requestMapper, responseMapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
