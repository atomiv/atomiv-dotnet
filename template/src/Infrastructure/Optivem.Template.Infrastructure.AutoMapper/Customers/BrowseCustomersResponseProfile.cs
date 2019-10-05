using AutoMapper;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class BrowseCustomersResponseProfile : Profile
    {
        public BrowseCustomersResponseProfile()
        {
            CreateMap<PageAggregateRootsResponse<Customer>, BrowseCustomersResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.AggregateRoots))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));
        }
    }

    public class BrowseCustomersRecordResponseProfile : Profile
    {
        public BrowseCustomersRecordResponseProfile()
        {
            CreateMap<Customer, BrowseCustomersRecordResponse>();
        }
    }
}
