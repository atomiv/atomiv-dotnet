using AutoMapper;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class ListCustomersQueryResponseProfile : Profile
    {
        public ListCustomersQueryResponseProfile()
        {
            CreateMap<ListReadModel<CustomerIdNameReadModel>, ListCustomersQueryResponse>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(e => e.Records))
                .ForMember(dest => dest.TotalRecords, opt => opt.MapFrom(e => e.TotalRecords));

            CreateMap<CustomerIdNameReadModel, ListCustomersRecordResponse>();
        }
    }
}