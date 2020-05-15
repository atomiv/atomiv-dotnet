using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Domain.Orders;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Orders
{
    public class CreateOrderCommandResponseProfile : Profile
    {
        public CreateOrderCommandResponseProfile()
        {
            CreateMap<Order, CreateOrderCommandResponse>();

            CreateMap<OrderItem, CreateOrderItemResponse>();
        }
    }
}
