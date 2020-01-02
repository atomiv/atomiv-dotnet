using AutoMapper;
using Optivem.Template.Core.Application.Orders.Queries;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class FindOrderQueryResponseProfile : Profile
    {
        public FindOrderQueryResponseProfile()
        {
            CreateMap<Order, FindOrderQueryResponse>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(e => e.OrderItems));

            CreateMap<OrderItem, FindOrderItemQueryResponse>();
        }
    }
}