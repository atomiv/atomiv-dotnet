using AutoMapper;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Core.Domain.Products;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.EntityFrameworkCore.Orders
{
    public class OrderRecordProfile : Profile
    {
        public OrderRecordProfile()
        {
            CreateMap<OrderRecord, Order>()
                // .ForMember(e => e.OrderDetails, e => e.Ignore())
                .ConstructUsing(e => Create(e));
        }

        private static Order Create(OrderRecord record)
        {
            var id = new OrderIdentity(record.Id);
            var customerId = new CustomerIdentity(record.CustomerId);
            OrderStatus status = (OrderStatus)record.StatusId; // TODO: VC
            var orderDetails = record.OrderDetails.Select(Create).ToList().AsReadOnly();

            // TODO: VC: OrderDetails is empty list, need to Include it in EF so that it loads...

            return new Order(id, customerId, status, orderDetails);
        }

        private static OrderDetail Create(OrderDetailRecord record)
        {
            var id = new OrderDetailIdentity(record.Id);
            var productId = new ProductIdentity(record.ProductId);
            var quantity = record.Quantity;
            var unitPrice = record.UnitPrice;
            var status = (OrderDetailStatus)record.StatusId; // TODO: VC

            return new OrderDetail(id, productId, quantity, unitPrice, status);
        }
    }
}
