using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class CreateOrderResponseProfile : Profile
    {
        public CreateOrderResponseProfile()
        {
            CreateMap<Order, CreateOrderResponse>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(e => e.OrderItems));

            CreateMap<OrderItem, CreateOrderResponse.OrderDetail>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(e => e.Status));
        }
    }
}