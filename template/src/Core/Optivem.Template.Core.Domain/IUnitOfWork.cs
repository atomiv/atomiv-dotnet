using Optivem.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Domain
{
    public interface IUnitOfWork : ITransactionalUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }

        IOrderRepository OrderRepository { get; }

        IProductRepository ProductRepository { get; }
    }
}
