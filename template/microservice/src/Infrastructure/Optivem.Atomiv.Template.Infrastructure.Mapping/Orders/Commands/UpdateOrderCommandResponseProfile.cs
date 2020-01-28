using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Domain.Orders;

namespace Optivem.Atomiv.Template.Infrastructure.Mapping.Orders
{
    public class UpdateOrderCommandResponseProfile : Profile
    {
        public UpdateOrderCommandResponseProfile()
        {
            CreateMap<Order, UpdateOrderCommandResponse>();

            CreateMap<OrderItem, UpdateOrderItemCommandResponse>();
        }
    }
}
