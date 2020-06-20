using Atomiv.Core.Domain;
using Atomiv.Infrastructure.EntityFrameworkCore;
using Generator.Core.Domain.Customers;
using Generator.Infrastructure.EntityFrameworkCore.Customers.Repositories;

namespace Generator.Infrastructure.EntityFrameworkCore
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
