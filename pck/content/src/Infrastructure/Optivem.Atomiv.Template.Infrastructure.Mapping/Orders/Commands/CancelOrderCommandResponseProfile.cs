using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Orders.Commands;
using Optivem.Atomiv.Template.Core.Domain.Orders;

namespace Optivem.Atomiv.Template.Infrastructure.Mapping.Orders
{
    public class CancelOrderCommandResponseProfile : Profile
    {
        public CancelOrderCommandResponseProfile()
        {
            CreateMap<Order, CancelOrderCommandResponse>();
        }
    }
}
