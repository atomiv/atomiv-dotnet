using Optivem.Framework.Core.Application.Ports.Mappers;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Infrastructure.Application.UseCases.MediatR
{
    public class CreateCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TRequest, TResponse> 
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TRequest, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public CreateCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever) 
            : base(requestMapper, responseMapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var request = command.Request;
            var entity = RequestMapper.Map<TRequest, TEntity>(request);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }

    public class CreateHandler<TKey, TEntity, TCommand, TRequest, TResponse>
        : CreateCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TCommand, TRequest, TResponse>
        where TCommand : ICommand<TRequest, TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public CreateHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork)
            : base(requestMapper, responseMapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
