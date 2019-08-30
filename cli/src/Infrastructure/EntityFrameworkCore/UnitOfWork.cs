using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Repositories;

namespace Optivem.Cli.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
            AddRepository<IMyFooRepository>(new MyFooRepository(context));
        }
    }
}
