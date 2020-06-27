using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Core.Domain.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;
using Atomiv.Template.Infrastructure.Domain.Persistence;
using SequentialGuid;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Orders
{
    public class OrderRepository : OrderReadonlyRepository, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task AddAsync(Order order)
        {
            var orderRecord = GetOrderRecord(order);
            Context.Orders.Add(orderRecord);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(OrderIdentity orderId)
        {
            var orderRecord = GetOrderRecord(orderId);
            Context.Remove(orderRecord);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            var orderRecordId = order.Id.ToGuid();

            var orderRecord = await Context.Orders
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            UpdateOrderRecord(orderRecord, order);

            try
            {
                Context.Orders.Update(orderRecord);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }
        public async Task<Order> FindAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.ToGuid();

            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        private OrderRecord GetOrderRecord(Order order)
        {
            var orderRecordId = order.Id.ToGuid();
            var customerRecordId = order.CustomerId.ToGuid();

            var orderItemRecords = order.OrderItems
                .Select(e => GetOrderItemRecord(e, orderRecordId))
                .ToList();

            return new OrderRecord
            {
                Id = orderRecordId,
                CustomerId = customerRecordId,
                OrderStatusId = order.Status,
                OrderItems = orderItemRecords,
            };
        }

        private OrderRecord GetOrderRecord(OrderIdentity orderId)
        {
            return new OrderRecord
            {
                Id = orderId.ToGuid(),
            };
        }

        private OrderItemRecord GetOrderItemRecord(IReadonlyOrderItem orderItem, Guid orderRecordId)
        {
            return new OrderItemRecord
            {
                Id = orderItem.Id.ToGuid(),
                OrderId = orderRecordId,
                ProductId = orderItem.ProductId.ToGuid(),
                StatusId = orderItem.Status,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }

        private void UpdateOrderRecord(OrderRecord record, Order order)
        {
            record.CustomerId = order.CustomerId.ToGuid();
            record.OrderStatusId = order.Status;

            var addedOrderDetails = order.OrderItems
                .Where(e => !record.OrderItems.Any(f => f.Id == e.Id.ToGuid()))
                .ToList();

            var addedOrderDetailRecords = addedOrderDetails
                .Select(e => CreateOrderItemRecord(e))
                .ToList();

            var removedOrderDetailRecords = record.OrderItems
                .Where(e => !order.OrderItems.Any(f => f.Id.ToGuid() == e.Id))
                .ToList();

            var updatedOrderDetailRecords = record.OrderItems
                .Where(e => order.OrderItems.Any(f => f.Id.ToGuid() == e.Id))
                .ToList();

            foreach (var addedOrderDetailRecord in addedOrderDetailRecords)
            {
                record.OrderItems.Add(addedOrderDetailRecord);
            }

            foreach (var removedOrderDetailRecord in removedOrderDetailRecords)
            {
                record.OrderItems.Remove(removedOrderDetailRecord);
            }

            foreach (var updatedOrderDetailRecord in updatedOrderDetailRecords)
            {
                var orderItem = order.OrderItems
                    .Single(e => e.Id.ToGuid() == updatedOrderDetailRecord.Id);

                UpdateOrderItemRecord(updatedOrderDetailRecord, orderItem);
            }
        }

        private OrderItemRecord CreateOrderItemRecord(IReadonlyOrderItem orderItem)
        {
            return new OrderItemRecord
            {
                ProductId = orderItem.ProductId.ToGuid(),
                StatusId = orderItem.Status,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }

        private void UpdateOrderItemRecord(OrderItemRecord orderItemRecord, IReadonlyOrderItem orderItem)
        {
            orderItemRecord.ProductId = orderItem.ProductId.ToGuid();
            orderItemRecord.StatusId = orderItem.Status;
            orderItemRecord.Quantity = orderItem.Quantity;
            orderItemRecord.UnitPrice = orderItem.UnitPrice;
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
    }
}