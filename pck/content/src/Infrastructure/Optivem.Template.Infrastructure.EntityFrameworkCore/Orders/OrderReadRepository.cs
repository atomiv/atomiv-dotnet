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

            return Context.OrderRecords.AsNoTracking()
                .AnyAsync(e => e.Id == orderRecordId);
        }

        public async Task<Order> FindAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.Id;

            var orderRecord = await Context.OrderRecords.AsNoTracking()
                .Include(e => e.OrderDetailRecords)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        public async Task<PageReadModel<OrderHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var orderRecords = await Context.OrderRecords.AsNoTracking()
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
            var orderRecords = await Context.OrderRecords.AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync();

            var resultRecords = orderRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListReadModel<OrderIdNameReadModel>(resultRecords, totalRecords);
        }

        public Task<long> CountAsync()
        {
            return Context.OrderRecords.LongCountAsync();
        }

        protected Order GetOrder(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerRecordId);
            OrderStatus status = (OrderStatus)record.OrderStatusRecordId; // TODO: VC
            var orderDetails = record.OrderDetailRecords.Select(GetOrderItem).ToList().AsReadOnly();

            // TODO: VC: OrderDetails is empty list, need to Include it in EF so that it loads...

            return new Order(id, customerId, DateTime.Now, status, orderDetails);
        }

        protected OrderItem GetOrderItem(OrderDetailRecord record)
        {
            var id = new OrderItemIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductRecordId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderItemStatus)record.OrderDetailStatusRecordId; // TODO: VC

            return new OrderItem(id, productId, quantity, unitPrice, status);
        }

        protected OrderHeaderReadModel GetOrderHeaderReadModel(OrderRecord record)
        {
            var orderId = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerRecordId);
            var orderDate = record.OrderDate;
            var status = (OrderStatus) record.OrderStatusRecordId;
            var totalPrice = record.OrderDetailRecords.Sum(e => e.UnitPrice * e.Quantity);

            return new OrderHeaderReadModel(orderId, customerId, orderDate, status, totalPrice);
        }

        protected OrderIdNameReadModel GetIdNameResult(OrderRecord record)
        {
            var id = record.Id;
            var name = record.Id.ToString();

            return new OrderIdNameReadModel(id, name);
        }
    }
}
