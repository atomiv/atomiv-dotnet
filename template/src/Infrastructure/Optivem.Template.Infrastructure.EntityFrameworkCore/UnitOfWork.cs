using Optivem.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : TransactionalUnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, bool disposeContext = false)
            : base(context, disposeContext)
        {
            CustomerRepository = new CustomerRepository(context);
            
            // TODO: VC: Create other repositories

        }

        public ICustomerRepository CustomerRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }
    }
}
