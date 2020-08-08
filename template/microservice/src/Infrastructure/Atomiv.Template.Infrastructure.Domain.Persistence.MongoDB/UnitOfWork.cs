using Atomiv.Core.Application;
using Atomiv.Infrastructure.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
        }
    }
}
