using Optivem.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application
{
    public class ListUseCase<TRequest, TResponse, TRecordResponse, TEntity, TId> : IListUseCase<TRequest, TResponse>
        where TRequest : IListRequest
        where TResponse : IListResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IListElementResponse<TId>
        where TEntity : class, IEntity<TId>
    {
        public ListUseCase(IResponseMapper responseMapper, IReadonlyRepository<TEntity, TId> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var entities = await Repository.GetAsync();
            var records = ResponseMapper.MapEnumerable<TEntity, TRecordResponse>(entities).ToList();

            return new TResponse
            {
                Data = records,
            };
        }
    }
}
