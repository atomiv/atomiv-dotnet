using AutoMapper;
using Optivem.Template.Core.Domain.Orders;
using System;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<OrderIdentity, Guid>()
                .ConvertUsing(src => src.Id);

            CreateMap<OrderItemIdentity, Guid>()
                .ConvertUsing(src => src.Id);
        }
    }
}