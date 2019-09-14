using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public class UnitOfWork : UnitOfWork<DatabaseContext>, IUnitOfWork
    {
        public UnitOfWork(DatabaseContext context, IMapper mapper, bool disposeContext = false)
            : base(context, disposeContext)
        {
            AddRepository<ICustomerRepository>(new CustomerRepository(context, mapper));
            AddRepository<IOrderRepository>(new OrderRepository(context, mapper));
            AddRepository<IProductRepository>(new ProductRepository(context, mapper));
        }
    }
}
