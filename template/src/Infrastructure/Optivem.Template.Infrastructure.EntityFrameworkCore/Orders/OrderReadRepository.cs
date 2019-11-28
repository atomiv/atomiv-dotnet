using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderReadRepository : Repository, IOrderReadRepository
    {
        public OrderReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.Id;

            return Context.Orders.AsNoTracking()
                .AnyAsync(e => e.Id == orderRecordId);
        }

        public async Task<Order> FindAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.Id;

            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        public async Task<PageReadModel<OrderHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .Page(pageQuery)
                .ToListAsync();

            var orderHeaderReadModels = orderRecords
                .Select(GetOrderHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return PageReadModel<OrderHeaderReadModel>.Create(pageQuery, orderHeaderReadModels, totalRecords);
        }

        public async Task<ListReadModel<OrderIdNameReadModel>> ListAsync()
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync();

            var resultRecords = orderRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListReadModel<OrderIdNameReadModel>(resultRecords, totalRecords);
        }

        public Task<long> CountAsync()
        {
            return Context.Orders.LongCountAsync();
        }

        protected Order GetOrder(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerId);
            OrderStatus status = (OrderStatus)record.OrderStatusId; // TODO: VC
            var orderDetails = record.OrderItems.Select(GetOrderItem).ToList().AsReadOnly();

            // TODO: VC: OrderDetails is empty list, need to Include it in EF so that it loads...

            return new Order(id, customerId, DateTime.Now, status, orderDetails);
        }

        protected OrderItem GetOrderItem(OrderItemRecord record)
        {
            var id = new OrderItemIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderItemStatus)record.OrderItemStatusId; // TODO: VC

            return new OrderItem(id, productId, quantity, unitPrice, status);
        }

        protected OrderHeaderReadModel GetOrderHeaderReadModel(OrderRecord record)
        {
            var orderId = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerId);
            var orderDate = record.OrderDate;
            var status = (OrderStatus) record.OrderStatusId;
            var totalPrice = record.OrderItems.Sum(e => e.UnitPrice * e.Quantity);

            return new OrderHeaderReadModel(orderId, customerId, orderDate, status, totalPrice);
        }

        protected OrderIdNameReadModel GetIdNameResult(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var name = record.Id.ToString();

            return new OrderIdNameReadModel(id, name);
        }
    }
}
