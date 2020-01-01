using AutoMapper;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class CreateOrderResponseProfile : Profile
    {
        public CreateOrderResponseProfile()
        {
            CreateMap<Order, CreateOrderResponse>();
                // .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems)); // TODO: VC: DELETE

            CreateMap<OrderItem, CreateOrderItemResponse>();
        }
    }
}
