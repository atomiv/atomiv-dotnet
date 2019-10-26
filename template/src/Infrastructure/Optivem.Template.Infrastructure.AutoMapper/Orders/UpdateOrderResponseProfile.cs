using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class UpdateOrderResponseProfile : Profile
    {
        public UpdateOrderResponseProfile()
        {
            CreateMap<Order, UpdateOrderResponse>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));

            CreateMap<OrderDetail, UpdateOrderResponse.OrderDetail>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));
        }
    }
}
