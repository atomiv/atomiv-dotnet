using Optivem.Framework.Infrastructure.EntityFrameworkCore.Mappers.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Mappers
{
    public class UpdateOrderMapper : IUpdateAggregateRootMapper<Order, OrderRecord>
    {
        public OrderRecord Map(Order aggregateRoot, OrderRecord record)
        {
            record.CustomerRecordId = aggregateRoot.CustomerId.Id;
            record.OrderStatusRecordId = (byte)aggregateRoot.Status;

            var addedOrderDetails = aggregateRoot.OrderDetails
                .Where(e => e.Id == OrderDetailIdentity.New);

            var addedOrderDetailRecords = addedOrderDetails
                .Select(e => CreateOrderDetailRecord(e))
                .ToList();

            var removedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => !aggregateRoot.OrderDetails.Any(f => f.Id.Id == e.Id))
                .ToList();

            var updatedOrderDetailRecords = record.OrderDetailRecords
                .Where(e => aggregateRoot.OrderDetails.Any(f => f.Id.Id == e.Id))
                .ToList();

            foreach(var addedOrderDetailRecord in addedOrderDetailRecords)
            {
                record.OrderDetailRecords.Add(addedOrderDetailRecord);
            }

            foreach(var removedOrderDetailRecord in removedOrderDetailRecords)
            {
                record.OrderDetailRecords.Remove(removedOrderDetailRecord);
            }

            foreach(var updatedOrderDetailRecord in updatedOrderDetailRecords)
            {
                var orderDetail = aggregateRoot.OrderDetails.Single(e => e.Id.Id == updatedOrderDetailRecord.Id);

                UpdateOrderDetailRecord(orderDetail, updatedOrderDetailRecord);
            }

            return record;
        }

        private OrderDetailRecord CreateOrderDetailRecord(OrderDetail orderDetail)
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

        private void UpdateOrderDetailRecord(OrderDetail orderDetail, OrderDetailRecord orderDetailRecord)
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
