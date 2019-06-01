using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class ListCustomersElementResponseProfile : ResponseProfile<Customer, ListCustomersElementResponse>
    {
        protected override void Extend(IMappingExpression<Customer, ListCustomersElementResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}