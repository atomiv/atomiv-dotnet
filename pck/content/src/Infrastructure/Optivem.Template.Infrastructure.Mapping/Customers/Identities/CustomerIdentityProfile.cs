using AutoMapper;
using Optivem.Template.Core.Domain.Customers;
using System;

namespace Optivem.Template.Infrastructure.Mapping.Customers
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