using AutoMapper;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Common
{
    public class OrderIdentityProfile : Profile
    {
        public OrderIdentityProfile()
        {
            CreateMap<OrderIdentity, string>()
                .ConvertUsing(src => src.Value);

            CreateMap<OrderItemIdentity, string>()
                .ConvertUsing(src => src.Value);
        }
    }
}