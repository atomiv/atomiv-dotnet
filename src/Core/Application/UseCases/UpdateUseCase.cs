using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class UpdateUseCase<TRequest, TResponse, TEntity, TId> : IUpdateUseCase<TRequest, TResponse>
        where TRequest : IUpdateRequest<TId>
        where TResponse : class, IUpdateResponse<TId>
        where TEntity : class, IEntity<TId>
    {
        public UpdateUseCase(IRequestMapper<TRequest, TEntity> requestMapper, IResponseMapper<TEntity, TResponse> responseMapper, IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper<TRequest, TEntity> RequestMapper { get; private set; }

        protected IResponseMapper<TEntity, TResponse> ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if (!exists)
            {
                return null;
            }

            var entity = RequestMapper.Map(request);

            try
            {
                Repository.Update(entity);
                await UnitOfWork.SaveChangesAsync();

                var retrieved = await Repository.GetSingleOrDefaultAsync(id);

                if (retrieved == null)
                {
                    return null;
                }

                var response = ResponseMapper.Map(retrieved);
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
}
