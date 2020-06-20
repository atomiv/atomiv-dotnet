using AutoMapper;
using Generator.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Infrastructure.AutoMapper.Customers
{
    public class CustomerIdentityProfile : Profile
    {
        public CustomerIdentityProfile()
        {
            CreateMap<int, CustomerIdentity>()
                .ConvertUsing(src => new CustomerIdentity(src));

            CreateMap<CustomerIdentity, int>()
                .ConvertUsing(src => src.Id);
        }
    }
}
