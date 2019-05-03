using Optivem.Framework.Core.Application.Ports.Out.Mappers;
using Optivem.Framework.Core.Application.Ports.In.UseCases;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Ports.Out.Repositories;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class CreateUseCase<TRequest, TResponse, TEntity, TKey> : ICreateUseCase<TRequest, TResponse>
        where TEntity: class, IEntity<TKey>
    {
        public CreateUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper RequestMapper { get; private set; }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TKey> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var entity = RequestMapper.Map<TRequest, TEntity>(request);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }
}