using AutoMapper;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class FindCustomerQueryResponseProfile : Profile
    {
        public FindCustomerQueryResponseProfile()
        {
            CreateMap<CustomerDetailReadModel, FindCustomerQueryResponse>();
        }
    }
}