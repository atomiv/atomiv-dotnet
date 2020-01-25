using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using System;

namespace Optivem.Template.Infrastructure.Persistence
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
            Id = Guid.NewGuid(); // TODO: VC: DELETE
        }

        public Guid Id { get; }
    }
}