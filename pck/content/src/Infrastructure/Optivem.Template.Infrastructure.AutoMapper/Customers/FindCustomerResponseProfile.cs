using AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class FindCustomerResponseProfile : Profile
    {
        public FindCustomerResponseProfile()
        {
            CreateMap<CustomerDetailReadModel, FindCustomerResponse>();
        }
    }
}