using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Generator.Core.Domain.Customers.Repositories;
using Optivem.Generator.Infrastructure.EntityFrameworkCore.Customers.Repositories;

namespace Optivem.Generator.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
            AddRepository<ICustomerRepository>(new CustomerRepository(context));
        }
    }
}
