using AutoMapper;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class UpdateOrderResponseProfile : Profile
    {
        public UpdateOrderResponseProfile()
        {
            CreateMap<Order, UpdateOrderResponse>();
            // .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems)); // TODO: VC: DELETE

            CreateMap<OrderItem, UpdateOrderItemResponse>();
        }
    }
}
