using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping.Customers
{
    public class UpdateCustomerResponseProfile : ResponseProfile<Customer, UpdateCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, UpdateCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
