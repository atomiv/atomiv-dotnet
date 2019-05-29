using Optivem.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class ListUseCase<TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> : IListUseCase<TRequest, TResponse>
        where TRequest : IListRequest
        where TResponse : IListResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IListElementResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListUseCase(IResponseMapper responseMapper, IReadonlyCrudRepository<TAggregateRoot, TIdentity> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyCrudRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var aggregateRoots = await Repository.GetAsync();
            var records = ResponseMapper.MapEnumerable<TAggregateRoot, TRecordResponse>(aggregateRoots).ToList();

            return new TResponse
            {
                Data = records,
            };
        }
    }
}