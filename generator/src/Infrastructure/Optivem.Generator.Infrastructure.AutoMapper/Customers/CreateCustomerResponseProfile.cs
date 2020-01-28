using AutoMapper;
using Optivem.Atomiv.Infrastructure.AutoMapper;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers;

namespace Optivem.Generator.Infrastructure.AutoMapper.Customers
{
    public class CreateCustomerResponseProfile : Profile
    {
        public CreateCustomerResponseProfile()
        {
            CreateMap<Customer, CreateCustomerResponse>();
        }
    }
}