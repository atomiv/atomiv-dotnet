using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class RepositoryUseCase<TRepository, TRequest, TResponse> : UseCase<TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
        public RepositoryUseCase(IMapper mapper, TRepository repository)
        {
            Mapper = mapper;
            Repository = repository;
        }

        protected IMapper Mapper { get; }

        protected TRepository Repository { get; }
    }
}
