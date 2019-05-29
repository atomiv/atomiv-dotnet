using Optivem.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class UpdateUseCase<TRequest, TResponse, TAggregateRoot, TIdentity> : IUpdateUseCase<TRequest, TResponse>
        where TRequest : IUpdateRequest<TIdentity>
        where TResponse : class, IUpdateResponse<TIdentity>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public UpdateUseCase(IRequestMapper<TRequest, TAggregateRoot> requestMapper, IResponseMapper<TAggregateRoot, TResponse> responseMapper, IUnitOfWork unitOfWork, ICrudRepository<TAggregateRoot, TIdentity> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper<TRequest, TAggregateRoot> RequestMapper { get; private set; }

        protected IResponseMapper<TAggregateRoot, TResponse> ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected ICrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var id = request.Id;

            var exists = await Repository.GetExistsAsync(id);

            if (!exists)
            {
                return null;
            }

            var aggregateRoot = RequestMapper.Map(request);

            try
            {
                Repository.Update(aggregateRoot);
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