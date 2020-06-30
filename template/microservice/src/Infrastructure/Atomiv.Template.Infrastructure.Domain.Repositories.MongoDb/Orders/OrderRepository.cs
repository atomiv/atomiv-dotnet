using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Orders
{
    public class OrderRepository : OrderReadonlyRepository, IOrderRepository
    {
        public OrderRepository(MongoDbContext context) : base(context)
        {
        }

        public Task AddAsync(Order order)
        {
            var orderRecord = GetOrderRecord(order);

            return Context.Orders.InsertOneAsync(orderRecord);
        }

        public async Task<Order> FindAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.TryToObjectId();

            if (orderRecordId == null)
            {
                return null;
            }

            var orderRecord = await Context.Orders
                .Find(e => e.Id == orderRecordId)
                .FirstOrDefaultAsync();

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        public Task RemoveAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.ToObjectId();

            return Context.Orders
                .DeleteOneAsync(e => e.Id == orderRecordId);
        }

        public Task UpdateAsync(Order order)
        {
            var orderRecordId = order.Id.ToObjectId();

            var orderRecordFilter = Builders<OrderRecord>.Filter
                .Eq(e => e.Id, orderRecordId);

            var orderRecord = GetOrderRecord(order);

            return Context.Orders.FindOneAndReplaceAsync(orderRecordFilter, orderRecord);
        }

        #region Helper

        private OrderRecord GetOrderRecord(Order order)
        {
            var orderRecordId = order.Id.ToObjectId();
            var customerRecordId = order.CustomerId.ToObjectId();

            var orderItemRecords = order.OrderItems
                .Select(GetOrderItemRecord)
                .ToList();

            return new OrderRecord
            {
                Id = orderRecordId,
                CustomerId = customerRecordId,
                OrderStatusId = order.Status,
                OrderItems = orderItemRecords,
            };
        }

        private OrderItemRecord GetOrderItemRecord(IReadonlyOrderItem orderItem)
        {
            return new OrderItemRecord
            {
                Id = orderItem.Id.ToObjectId(),
                ProductId = orderItem.ProductId.ToObjectId(),
                StatusId = orderItem.Status,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }

        private Order GetOrder(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id.ToString());
            var customerId = new CustomerIdentity(record.CustomerId.ToString());
            var status = record.OrderStatusId;
            var orderDetails = record.OrderItems.Select(GetOrderItem).ToList().AsReadOnly();

            return new Order(id, customerId, DateTime.Now, status, orderDetails);
        }

        private OrderItem GetOrderItem(OrderItemRecord orderItemRecord)
        {
            var id = new OrderItemIdentity(orderItemRecord.Id.ToString());
            var productId = new ProductIdentity(orderItemRecord.ProductId.ToString());
            var quantity = (int)orderItemRecord.Quantity; // TODO: VC: Make int
            var unitPrice = orderItemRecord.UnitPrice;
            var status = orderItemRecord.StatusId;

            return new OrderItem(id, productId, unitPrice, quantity, status);
        }

        #endregion
    }
}
