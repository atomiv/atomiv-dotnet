using AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

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