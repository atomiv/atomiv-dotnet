﻿using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Domain.Orders;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Orders
{
    public class SubmitOrderCommandResponseProfile : Profile
    {
        public SubmitOrderCommandResponseProfile()
        {
            CreateMap<Order, SubmitOrderCommandResponse>();
        }
    }
}
