using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Infrastructure.AutoMapper.Customers
{
    public class CreateCustomerResponseProfile : Profile
    {
        public CreateCustomerResponseProfile()
        {
            CreateMap<Customer, CreateCustomerResponse>();
        }
    }
}