using Optivem.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class ListAggregatesUseCase<TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public ListAggregatesUseCase(IResponseMapper responseMapper, IReadonlyRepository<TAggregateRoot, TIdentity> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyRepository<TAggregateRoot, TIdentity> Repository { get; private set; }

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