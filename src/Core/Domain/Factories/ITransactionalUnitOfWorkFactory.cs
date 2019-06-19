using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public interface ITransactionalUnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : ITransactionalUnitOfWork
    {
        TUnitOfWork Create();
    }
}
