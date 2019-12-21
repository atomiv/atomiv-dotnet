using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class UpdateOrderResponseProfile : Profile
    {
        public UpdateOrderResponseProfile()
        {
            CreateMap<Order, UpdateOrderResponse>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems));

            CreateMap<OrderItem, UpdateOrderItemResponse>();
        }
    }
}
