using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class CreateOrderResponseProfile : Profile
    {
        public CreateOrderResponseProfile()
        {
            CreateMap<Order, CreateOrderResponse>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));

            CreateMap<OrderDetail, CreateOrderResponse.OrderDetail>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));
        }
    }
}
