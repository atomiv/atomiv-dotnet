using Atomiv.Core.Application;
using Atomiv.Infrastructure.EntityFrameworkCore;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.Common
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
        }
    }
}