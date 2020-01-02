using AutoMapper;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Orders
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
