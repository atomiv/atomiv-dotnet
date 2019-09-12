using AutoMapper;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Orders
{
    public class FindOrderResponseProfile : Profile
    {
        public FindOrderResponseProfile()
        {
            CreateMap<Order, FindOrderResponse>();
        }
    }
}
