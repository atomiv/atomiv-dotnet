using AutoMapper;
using Optivem.Atomiv.Infrastructure.AutoMapper;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers;

namespace Optivem.Generator.Infrastructure.AutoMapper.Customers
{
    public class UpdateCustomerResponseProfile : Profile
    {
        public UpdateCustomerResponseProfile()
        {
            CreateMap<Customer, UpdateCustomerResponse>();
        }
    }
}
