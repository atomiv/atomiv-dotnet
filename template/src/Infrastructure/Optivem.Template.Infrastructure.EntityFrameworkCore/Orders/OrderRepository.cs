using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders
{
    public class OrderRepository : OrderReadRepository, IOrderRepository
    {
        public OrderRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Order> AddAsync(Order order)
        {
            var orderRecord = GetOrderRecord(order);
            Context.OrderRecords.Add(orderRecord);
            await Context.SaveChangesAsync();
            return GetOrder(orderRecord);
        }

        public async Task RemoveAsync(OrderIdentity orderId)
        {
            var orderRecord = GetOrderRecord(orderId);
            Context.Remove(orderRecord);
            await Context.SaveChangesAsync();
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var orderRecordId = order.Id.Id;
            var orderRecord = await Context.OrderRecords
                .Include(e => e.OrderDetailRecords)
                .FirstOrDefaultAsync(e => e.Id == orderRecordId);

            UpdateOrderRecord(orderRecord, order);

            try
            {
                Context.OrderRecords.Update(orderRecord);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }

            return GetOrder(orderRecord);
        }

        protected OrderRecord GetOrderRecord(Order order)
        {
            var id = order.Id.Id;
            var customerRecordId = order.CustomerId.Id;
            var orderStatusRecordId = (byte)order.Status;
            var orderDetailRecords = order.OrderItems.Select(e => GetOrderDetailRecord(e, id)).ToList();

            return new OrderRecord
            {
                Id = id,
                CustomerRecordId = customerRecordId,
                OrderStatusRecordId = orderStatusRecordId,
                OrderDetailRecords = orderDetailRecords,
            };
        }

        protected OrderRecord GetOrderRecord(OrderIdentity orderId)
        {
            var id = orderId.Id;

            return new OrderRecord
            {
                Id = id,
            };
        }

        protected OrderDetailRecord GetOrderDetailRecord(OrderItem orderDetail, Guid orderRecordId)
        {
            var id = orderDetail.Id.Id;
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            return new OrderDetailRecord
            {
                Id = id,
                OrderRecordId = orderRecordId,
                ProductRecordId = productRecordId,
                OrderDetailStatusRecordId = orderDetailStatusRecordId,
                Quantity = quantity,
                UnitPrice = unitPrice,
            };
        }

        protected void UpdateOrderRecord(OrderRecord record, Order order)
        {
            record.CustomerRecordId = order.CustomerId.Id;
            record.OrderStatusRecordId = (byte)order.Status;

            var addedOrderDetails = order.OrderItems
                .Where(e => !record.OrderDetailRecords.Any(f => f.Id == e.Id.Id))
                .ToList();

            var addedOrderDetailRecords = addedOrderDetails
                .Select(e => CreateOrderDetailRecord(e))
                .ToList();

            var removedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => !order.OrderItems.Any(f => f.Id.Id == e.Id))
                .ToList();

            var updatedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => order.OrderItems.Any(f => f.Id.Id == e.Id))
                .ToList();

            foreach (var addedOrderDetailRecord in addedOrderDetailRecords)
            {
                record.OrderDetailRecords.Add(addedOrderDetailRecord);
            }

            foreach (var removedOrderDetailRecord in removedOrderDetailRecords)
            {
                record.OrderDetailRecords.Remove(removedOrderDetailRecord);
            }

            foreach (var updatedOrderDetailRecord in updatedOrderDetailRecords)
            {
                var orderDetail = order.OrderItems.Single(e => e.Id.Id == updatedOrderDetailRecord.Id);

                UpdateOrderDetailRecord(updatedOrderDetailRecord, orderDetail);
            }
        }

        private OrderDetailRecord CreateOrderDetailRecord(OrderItem orderDetail)
        {
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            return new OrderDetailRecord
            {
                ProductRecordId = productRecordId,
                OrderDetailStatusRecordId = orderDetailStatusRecordId,
                Quantity = quantity,
                UnitPrice = unitPrice,
            };
        }

        private void UpdateOrderDetailRecord(OrderDetailRecord orderDetailRecord, OrderItem orderDetail)
        {
            var productRecordId = orderDetail.ProductId.Id;
            var orderDetailStatusRecordId = (byte)orderDetail.Status;
            var quantity = orderDetail.Quantity;
            var unitPrice = orderDetail.UnitPrice;

            orderDetailRecord.ProductRecordId = productRecordId;
            orderDetailRecord.OrderDetailStatusRecordId = orderDetailStatusRecordId;
            orderDetailRecord.Quantity = quantity;
            orderDetailRecord.UnitPrice = unitPrice;
        }
    }
}