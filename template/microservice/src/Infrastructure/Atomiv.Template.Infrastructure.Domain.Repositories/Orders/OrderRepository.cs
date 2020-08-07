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

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Orders
{
    public class OrderRepository : OrderReadonlyRepository, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public Task AddAsync(Order order)
        {
            var orderRecord = GetOrderRecord(order);
            Context.Orders.Add(orderRecord);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(OrderIdentity orderId)
        {
            var orderRecord = GetOrderRecord(orderId);
            Context.Remove(orderRecord);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Order order)
        {
            var orderRecord = await Context.Orders
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == order.Id);

            UpdateOrderRecord(orderRecord, order);

            Context.Orders.Update(orderRecord);
        }
        public async Task<Order> FindAsync(OrderIdentity orderId)
        {
            var orderRecord = await Context.Orders.AsNoTracking()
                .Include(e => e.OrderItems)
                .FirstOrDefaultAsync(e => e.Id == orderId);

            if (orderRecord == null)
            {
                return null;
            }

            return GetOrder(orderRecord);
        }

        #region Helper

        private OrderRecord GetOrderRecord(Order order)
        {
            var orderRecordId = order.Id;
            var customerRecordId = order.CustomerId;

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
                Id = orderId,
            };
        }

        private OrderItemRecord GetOrderItemRecord(IReadonlyOrderItem orderItem, Guid orderRecordId)
        {
            return new OrderItemRecord
            {
                Id = orderItem.Id,
                OrderId = orderRecordId,
                ProductId = orderItem.ProductId,
                StatusId = orderItem.Status,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }

        private OrderItemRecord GetOrderItemRecord(IReadonlyOrderItem orderItem)
        {
            return new OrderItemRecord
            {
                Id = orderItem.Id,
                ProductId = orderItem.ProductId,
                StatusId = orderItem.Status,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
            };
        }

        private Order GetOrder(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerId);
            var status = record.OrderStatusId;
            var orderDetails = record.OrderItems.Select(GetOrderItem).ToList().AsReadOnly();

            return new Order(id, customerId, DateTime.Now, status, orderDetails);
        }

        private OrderItem GetOrderItem(OrderItemRecord orderItemRecord)
        {
            var id = new OrderItemIdentity(orderItemRecord.Id);
            var productId = new ProductIdentity(orderItemRecord.ProductId);
            var quantity = (int)orderItemRecord.Quantity; // TODO: VC: Make int
            var unitPrice = orderItemRecord.UnitPrice;
            var status = orderItemRecord.StatusId;

            return new OrderItem(id, productId, unitPrice, quantity, status);
        }

        private void UpdateOrderRecord(OrderRecord record, Order order)
        {
            record.CustomerId = order.CustomerId;
            record.OrderStatusId = order.Status;

            var addedOrderDetails = order.OrderItems
                .Where(e => !record.OrderItems.Any(f => f.Id == e.Id))
                .ToList();

            var addedOrderDetailRecords = addedOrderDetails
                .Select(e => GetOrderItemRecord(e))
                .ToList();

            var removedOrderDetailRecords = record.OrderItems
                .Where(e => !order.OrderItems.Any(f => f.Id == e.Id))
                .ToList();

            var updatedOrderDetailRecords = record.OrderItems
                .Where(e => order.OrderItems.Any(f => f.Id == e.Id))
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
                    .Single(e => e.Id == updatedOrderDetailRecord.Id);

                UpdateOrderItemRecord(updatedOrderDetailRecord, orderItem);
            }
        }

        private void UpdateOrderItemRecord(OrderItemRecord orderItemRecord, IReadonlyOrderItem orderItem)
        {
            orderItemRecord.ProductId = orderItem.ProductId;
            orderItemRecord.StatusId = orderItem.Status;
            orderItemRecord.Quantity = orderItem.Quantity;
            orderItemRecord.UnitPrice = orderItem.UnitPrice;
        }

        #endregion
    }
}