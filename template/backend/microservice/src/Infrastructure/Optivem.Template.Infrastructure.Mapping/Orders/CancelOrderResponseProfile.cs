using AutoMapper;
using Optivem.Template.Core.Application.Orders.Commands;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Orders
{
    public class CancelOrderResponseProfile : Profile
    {
        public CancelOrderResponseProfile()
        {
            CreateMap<Order, CancelOrderResponse>();
        }
    }
}
