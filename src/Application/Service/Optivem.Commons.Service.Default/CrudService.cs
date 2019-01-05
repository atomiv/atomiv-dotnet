using Optivem.Commons.Mapping;
using Optivem.Commons.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Commons.Service.Default
{
    public class CrudService<TMappingService, TUnitOfWork, TRepository, TRequest, TResponse, TEntity, TKey> : ICrudService<TRequest, TResponse, TKey>
        where TMappingService : IMappingService
        where TUnitOfWork : IUnitOfWork
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly TMappingService mappingService;
        protected readonly TUnitOfWork unitOfWork;
        protected readonly TRepository repository;

        public CrudService(TMappingService mappingService, TUnitOfWork unitOfWork, Func<TUnitOfWork, TRepository> repositoryRetriever)
        {
            this.mappingService = mappingService;
            this.unitOfWork = unitOfWork;
            this.repository = repositoryRetriever(unitOfWork);
        }

        public virtual TResponse Add(TRequest request)
        {
            var entity = mappingService.Map<TRequest, TEntity>(request);
            repository.Add(entity);
            unitOfWork.SaveChanges();
            var response = mappingService.Map<TEntity, TResponse>(entity);
            return response;
        }

        public virtual void Delete(TKey id)
        {
            var entity = repository.GetSingleOrDefault(id);

            if (entity != null)
            {
                repository.Delete(entity);
            }
        }

        public virtual bool Exists(TKey id)
        {
            return repository.GetExists(id);
        }

        public virtual async Task<IEnumerable<TResponse>> GetAsync()
        {
            var entities = await repository.GetAsync();
            return mappingService.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);
        }

        public virtual async Task<TResponse> GetAsync(TKey id)
        {
            var entity = await repository.GetSingleOrDefaultAsync(id);
            return mappingService.Map<TEntity, TResponse>(entity);
        }

        public virtual void Update(TRequest request)
        {
            var entity = mappingService.Map<TRequest, TEntity>(request);
            repository.Update(entity);
        }

    }
}
