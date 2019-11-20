using Optivem.Framework.Core.Common;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, IRequestHandler requestHandler, bool disposeContext = false)
            : base(context, disposeContext)
        {
        }
    }
}