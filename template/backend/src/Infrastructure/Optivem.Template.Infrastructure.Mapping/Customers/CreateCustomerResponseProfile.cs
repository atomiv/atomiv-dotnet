using AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class CreateCustomerResponseProfile : Profile
    {
        public CreateCustomerResponseProfile()
        {
            CreateMap<Customer, CreateCustomerResponse>();
        }
    }
}