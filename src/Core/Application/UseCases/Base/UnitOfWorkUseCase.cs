using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UnitOfWorkUseCase<TRepository, TRequest, TResponse> 
        : UseCase<TRequest, TResponse>
        where TRepository : IRepository
        where TRequest : IRequest<TResponse>
        where TResponse : IResponse
    {
        public UnitOfWorkUseCase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        protected IMapper Mapper { get; set; }

        protected IUnitOfWork UnitOfWork { get; }

        protected TRepository GetRepository()
        {
            return UnitOfWork.GetRepository<TRepository>();
        }
    }

}
