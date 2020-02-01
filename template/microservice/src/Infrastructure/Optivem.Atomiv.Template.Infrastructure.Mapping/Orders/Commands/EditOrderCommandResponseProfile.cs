using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Domain.Orders;

namespace Optivem.Atomiv.Template.Infrastructure.Mapping.Orders
{
    public class EditOrderCommandResponseProfile : Profile
    {
        public EditOrderCommandResponseProfile()
        {
            CreateMap<Order, EditOrderCommandResponse>();

            CreateMap<OrderItem, UpdateOrderItemCommandResponse>();
        }
    }
}
