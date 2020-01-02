using AutoMapper;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class CreateOrderCommandResponseProfile : Profile
    {
        public CreateOrderCommandResponseProfile()
        {
            CreateMap<Order, CreateOrderCommandResponse>();
                // .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems)); // TODO: VC: DELETE

            CreateMap<OrderItem, CreateOrderItemResponse>();
        }
    }
}
