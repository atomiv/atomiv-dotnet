using AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class BrowseCustomersResponseProfile : Profile
    {
        public BrowseCustomersResponseProfile()
        {
            CreateMap<IEnumerable<Customer>, BrowseCustomersResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
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
