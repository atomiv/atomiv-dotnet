using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Customers.Responses;
using Optivem.NorthwindLite.Core.Domain.Customers;

namespace Optivem.NorthwindLite.Infrastructure.AutoMapper.Customers
{
    public class CreateCustomerResponseProfile : ResponseProfile<Customer, CreateCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, CreateCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}