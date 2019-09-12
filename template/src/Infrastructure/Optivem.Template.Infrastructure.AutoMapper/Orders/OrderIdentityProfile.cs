using AutoMapper;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<int, OrderIdentity>()
                .ConvertUsing(src => new OrderIdentity(src));

            CreateMap<OrderIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}
