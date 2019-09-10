using AutoMapper;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class UpdateCustomerRequestProfile : Profile
    {
        public UpdateCustomerRequestProfile()
        {
            CreateMap<UpdateCustomerRequest, Customer>();
        }
    }
}
