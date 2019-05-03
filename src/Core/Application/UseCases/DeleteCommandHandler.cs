using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class DeleteCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand>
        : BaseCommandHandler<TUnitOfWork, TRepository, TKey, TEntity, TCommand, TKey, bool>
        where TCommand : ICommand<TKey, bool>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteCommandHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
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
        public DeleteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
