using AutoMapper;
using Optivem.Template.Core.Domain.Customers;
using System;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class CustomerIdentityProfile : Profile
    {
        public CustomerIdentityProfile()
        {
            CreateMap<CustomerIdentity, Guid>()
                .ConvertUsing(src => src.Id);
        }
    }
}