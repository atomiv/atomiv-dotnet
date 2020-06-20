using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;

namespace Generator.Infrastructure.AutoMapper.Customers
{
    public class UpdateCustomerResponseProfile : Profile
    {
        public UpdateCustomerResponseProfile()
        {
            CreateMap<Customer, UpdateCustomerResponse>();
        }
    }
}
