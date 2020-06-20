using AutoMapper;
using Atomiv.Infrastructure.AutoMapper;
using Generator.Core.Application.Customers.Responses;
using Generator.Core.Domain.Customers;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Infrastructure.AutoMapper.Customers
{
    public class ListCustomersResponseProfile : Profile
    {
        public ListCustomersResponseProfile()
        {
            CreateMap<IEnumerable<Customer>, ListCustomersResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(e => e.Count()));
        }
    }

    public class ListCustomersRecordResponseProfile : Profile
    {
        public ListCustomersRecordResponseProfile()
        {
            CreateMap<Customer, ListCustomersRecordResponse>();
        }
    }
}
