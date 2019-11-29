using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class FindOrderResponseProfile : Profile
    {
        public FindOrderResponseProfile()
        {
            CreateMap<Order, FindOrderResponse>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems));

            CreateMap<OrderItem, FindOrderItemResponse>();
        }
    }
}