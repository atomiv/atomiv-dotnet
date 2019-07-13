using Optivem.Framework.Core.Application.UseCases.Base;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class ListAggregatesUseCase<TResponseMapper, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> 
        : RepositoryUseCase<TRepository, TRequest, TResponse>
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TResponseMapper : ICollectionResponseMapper<TAggregateRoot, TResponse>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(TRepository repository, TResponseMapper responseMapper)
            : base(repository)
        {
            ResponseMapper = responseMapper;
        }

        protected TResponseMapper ResponseMapper { get; private set; }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoots = await Repository.GetAsync();

            return ResponseMapper.Map(aggregateRoots);
        }
    }
    public class ListAggregatesUseCase<TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        : ListAggregatesUseCase<ICollectionResponseMapper<TAggregateRoot, TResponse>, TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        where TRepository : IFindAllAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(TRepository repository, ICollectionResponseMapper<TAggregateRoot, TResponse> responseMapper) : base(repository, responseMapper)
        {
        }
    }
}