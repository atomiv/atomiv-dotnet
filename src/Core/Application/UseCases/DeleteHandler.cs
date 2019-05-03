using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class DeleteHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest>
        : BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, bool>
        where TRequest : IIdentifiableCommand<TKey, bool>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;
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

    public class DeleteHandler<TKey, TEntity, TRequest>
        : DeleteHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest>
        where TRequest : IIdentifiableCommand<TKey, bool>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
