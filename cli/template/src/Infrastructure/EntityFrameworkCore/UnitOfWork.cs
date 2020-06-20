using Atomiv.Core.Domain;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Infrastructure.EntityFrameworkCore.MyFoos.Repositories;

namespace Cli.Infrastructure.EntityFrameworkCore
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
