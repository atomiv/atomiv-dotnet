using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Generator.Core.Application.Customers.Responses;
using Optivem.Generator.Core.Domain.Customers.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Generator.Infrastructure.AutoMapper.Customers
{
    public class ListCustomersResponseProfile : ResponseProfile<IEnumerable<Customer>, ListCustomersResponse>
    {
        protected override void Extend(IMappingExpression<IEnumerable<Customer>, ListCustomersResponse> map)
        {
            map.ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
        }
    }

    public class ListCustomersRecordResponseProfile : ResponseProfile<Customer, ListCustomersRecordResponse>
    {
        protected override void Extend(IMappingExpression<Customer, ListCustomersRecordResponse> map)
        {
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
