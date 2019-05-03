using Optivem.Framework.Core.Application.Ports.Mappers;
using Optivem.Framework.Core.Application.Ports.UseCases;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Ports.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    class FindAllUseCase<TResponse, TEntity, TKey> : IFindAllUseCase<TResponse>
        where TEntity : class, IEntity<TKey>
    {
        public FindAllUseCase(IResponseMapper responseMapper, IReadonlyRepository<TEntity, TKey> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyRepository<TEntity, TKey> Repository { get; private set; }

        public async Task<IEnumerable<TResponse>> HandleAsync()
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var entities = await Repository.GetAsync();
            var responses = ResponseMapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
            return responses;
        }
    }
}
