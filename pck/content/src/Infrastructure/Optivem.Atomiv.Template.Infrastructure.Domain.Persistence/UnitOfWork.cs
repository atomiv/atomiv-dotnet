using Optivem.Atomiv.Core.Domain;
using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;

namespace Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Common
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
        }
    }
}