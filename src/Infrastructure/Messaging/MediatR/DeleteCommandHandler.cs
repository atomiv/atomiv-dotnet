using Optivem.Core.Application;
using Optivem.Core.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Infrastructure.Messaging.MediatR
{
    public class DeleteCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TKey, bool>
        where TCommand : ICommand<TKey, bool>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(requestMapper, responseMapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<bool> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var id = command.Request;
            var entity = await Repository.GetSingleOrDefaultAsync(id);

            if(entity == null)
            {
                return false;
            }

            Repository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }

    public class DeleteCommandHandler<TKey, TEntity, TRequest>
        : DeleteCommandHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest>
        where TRequest : ICommand<TKey, bool>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteCommandHandler(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork)
            : base(requestMapper, responseMapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
