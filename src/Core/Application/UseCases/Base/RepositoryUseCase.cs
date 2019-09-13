using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases.Base
{
    public abstract class RepositoryUseCase<TRepository, TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public RepositoryUseCase(IMapper mapper, TRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        protected IMapper Mapper { get; }

        protected TRepository Repository { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);


    }
}
