using AutoMapper;
using Atomiv.Template.Core.Domain.Orders;
using System;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Common
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