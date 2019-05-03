using AutoMapper;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class UpdateHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        : BaseHandler<TUnitOfWork, TRepository, TKey, TEntity, TRequest, TResponse>
        where TRequest : IIdentifiableCommand<TKey, TResponse>
        where TResponse : class
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        public UpdateHandler(IMapper mapper, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
            : base(mapper, unitOfWork, repositoryRetriever)
        {
        }

        public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if(!exists)
            {
                return null;
            }

            var entity = Mapper.Map<TRequest, TEntity>(request);

            try
            {
                Repository.Update(entity);
                await UnitOfWork.SaveChangesAsync();

                var retrieved = await Repository.GetSingleOrDefaultAsync(id);

                if(retrieved == null)
                {
                    return null;
                }

                var response = Mapper.Map<TEntity, TResponse>(retrieved);
                return response;
            }
            catch (ConcurrentUpdateException)
            {
                exists = await Repository.GetExistsAsync(id);

                if (!exists)
                {
                    return null;
                }

                throw;
            }
        }
    }

    public class UpdateHandler<TKey, TEntity, TRequest, TResponse>
        : UpdateHandler<IUnitOfWork, IRepository<TEntity, TKey>, TKey, TEntity, TRequest, TResponse>
        where TRequest : IIdentifiableCommand<TKey, TResponse>
        where TResponse : class
        where TEntity : class, IEntity<TKey>
    {
        public UpdateHandler(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork, e => e.GetRepository<TEntity, TKey>())
        {

        }
    }
}
