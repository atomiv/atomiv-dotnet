using AutoMapper;
using Optivem.Template.Core.Domain.Orders;
using System;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<OrderIdentity, Guid>()
                .ConvertUsing(src => src.Value);

            CreateMap<OrderItemIdentity, Guid>()
                .ConvertUsing(src => src.Value);
        }
    }
}