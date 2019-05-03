using Optivem.Framework.Core.Application.Ports.In.UseCases;
using Optivem.Framework.Core.Domain.Entities;
using Optivem.Framework.Core.Domain.Ports.Repositories;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application.UseCases
{
    public class DeleteUseCase<TEntity, TKey> : IDeleteUseCase<TKey>
        where TEntity : class, IEntity<TKey>
    {
        public DeleteUseCase(IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TKey> Repository { get; private set; }

        public async Task<bool> HandleAsync(TKey request)
        {
            var id = request;
            var entity = await Repository.GetSingleOrDefaultAsync(id);

            if (entity == null)
            {
                return false;
            }

            Repository.Delete(entity);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
