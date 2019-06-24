using AutoMapper;
using Optivem.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
