using AutoMapper;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Common
{
    public class CustomerIdentityProfile : Profile
    {
        public CustomerIdentityProfile()
        {
            CreateMap<CustomerIdentity, Guid>()
                .ConvertUsing(src => src.Value);
        }
    }
}