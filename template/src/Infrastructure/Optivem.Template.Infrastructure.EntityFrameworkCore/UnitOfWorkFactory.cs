using Optivem.Core.Domain;
using Optivem.Template.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWorkFactory : ITransactionalUnitOfWorkFactory<IUnitOfWork>
    {
        public UnitOfWorkFactory(DatabaseContext context)
        {
            Context = context;
        }

        public DatabaseContext Context { get; }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(Context);
        }
    }
}
