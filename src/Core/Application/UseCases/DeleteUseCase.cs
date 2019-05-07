using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;
using Optivem.Core.Domain.Repositories;
using Optivem.Core.Domain.UnitOfWork;
using System.Threading.Tasks;

namespace Optivem.Core.Application.UseCases
{
    public class DeleteUseCase<TRequest, TResponse, TEntity, TId> : IDeleteUseCase<TRequest, TResponse>
        where TRequest : IDeleteRequest<TId>
        where TResponse : IDeleteResponse, new()
        where TEntity : class, IEntity<TId>
    {
        public DeleteUseCase(IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TId> Repository { get; private set; }

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
