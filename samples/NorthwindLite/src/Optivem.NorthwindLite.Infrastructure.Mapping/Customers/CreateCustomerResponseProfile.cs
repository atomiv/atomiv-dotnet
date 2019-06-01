using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
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