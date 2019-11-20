using AutoMapper;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class ListCustomersResponseProfile : Profile
    {
        public ListCustomersResponseProfile()
        {
            CreateMap<ListReadModel<CustomerIdNameReadModel>, ListCustomersResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.Records))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));

            CreateMap<CustomerIdNameReadModel, ListCustomersRecordResponse>();
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