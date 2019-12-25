using AutoMapper;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class FindCustomerResponseProfile : Profile
    {
        public FindCustomerResponseProfile()
        {
            CreateMap<CustomerDetailReadModel, FindCustomerResponse>();
        }
    }
}