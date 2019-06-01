using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Retrieve;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping.Customers
{
    public class FindCustomerResponseProfile : ResponseProfile<Customer, FindCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, FindCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}