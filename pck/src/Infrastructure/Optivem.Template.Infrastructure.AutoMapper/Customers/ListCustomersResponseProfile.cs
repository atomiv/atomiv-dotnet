using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
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
