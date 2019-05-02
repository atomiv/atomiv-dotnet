using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class DeleteHandler<TUnitOfWork, TRepository, TRequest, TEntity, TKey>
        : BaseHandler<TUnitOfWork, TRepository, TRequest, bool, TEntity, TKey>
        where TRequest : IIdentifiableRequest<bool, TKey>
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
            var entity = Repository.GetSingleOrDefault(id);

            if(entity == null)
            {
                return false;
            }

            Repository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
