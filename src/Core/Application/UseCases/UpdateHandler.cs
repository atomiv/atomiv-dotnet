using AutoMapper;
using MediatR;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class UpdateHandler<TUnitOfWork, TRepository, TRequest, TEntity, TKey>
        : BaseHandler<TUnitOfWork, TRepository, TRequest, bool, TEntity, TKey>
        where TRequest : IIdentifiableRequest<bool, TKey>
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public UpdateHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if(!exists)
            {
                return false;
            }

            var entity = Mapper.Map<TRequest, TEntity>(request);

            try
            {
                Repository.Update(entity);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            catch (ConcurrentUpdateException)
            {
                exists = await Repository.GetExistsAsync(id);

                if (!exists)
                {
                    return false;
                }

                throw;
            }
        }
    }
}
