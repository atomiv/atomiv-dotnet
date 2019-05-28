using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class DeleteUseCase<TRequest, TResponse, TEntity, TId> : IDeleteUseCase<TRequest, TResponse>
        where TRequest : IDeleteRequest<TId>
        where TResponse : IDeleteResponse, new()
        where TEntity : class, IEntity<TId>
    {
        public DeleteUseCase(IUnitOfWork unitOfWork, ICrudRepository<TEntity, TId> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;
            var entity = await Repository.GetSingleOrDefaultAsync(id);

            if (entity == null)
            {
                return new TResponse
                {
                    Deleted = false,
                };
            }

            Repository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();

            return new TResponse
            {
                Deleted = false,
            };
        }
    }
}