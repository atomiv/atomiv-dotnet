using AutoMapper;
using Optivem.Template.Core.Application.Customers.Requests;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class CreateCustomerRequestProfile : Profile
    {
        public CreateCustomerRequestProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>()
                .ConstructUsing(request => new Customer(CustomerIdentity.Null,
                    request.FirstName,
                    request.LastName));
        }
    }
}
