using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class UpdateOrderResponseProfile : Profile
    {
        public UpdateOrderResponseProfile()
        {
            CreateMap<Order, UpdateOrderResponse>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));

            CreateMap<OrderItem, UpdateOrderResponse.OrderDetail>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));
        }
    }
}
