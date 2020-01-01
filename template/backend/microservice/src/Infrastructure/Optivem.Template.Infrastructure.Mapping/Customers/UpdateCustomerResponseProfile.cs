using AutoMapper;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class UpdateCustomerResponseProfile : Profile
    {
        public UpdateCustomerResponseProfile()
        {
            CreateMap<Customer, UpdateCustomerResponse>();
        }
    }
}
