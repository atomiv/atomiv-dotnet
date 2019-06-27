using Optivem.Framework.Core.Application.UseCases.Base;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class BrowseAggregatesUseCase<TResponseMapper, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        : RepositoryUseCase<TRepository, TRequest, TResponse>
        where TRepository : IPageAggregatesRepository<TAggregateRoot, TIdentity>
        where TResponseMapper : ICollectionResponseMapper<TAggregateRoot, TResponse>
        where TRequest : ICollectionRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public BrowseAggregatesUseCase(TRepository repository, TResponseMapper responseMapper)
            : base(repository)
        {
            ResponseMapper = responseMapper;
        }

        protected TResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var aggregateRoots = await Repository.GetAsync(request.Page, request.Size);

            return ResponseMapper.Map(aggregateRoots);
        }
    }
    public class BrowseAggregatesUseCase<TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        : BrowseAggregatesUseCase<ICollectionResponseMapper<TAggregateRoot, TResponse>, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IPageAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : ICollectionRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public BrowseAggregatesUseCase(TRepository repository, ICollectionResponseMapper<TAggregateRoot, TResponse> responseMapper) : base(repository, responseMapper)
        {
        }
    }
}
