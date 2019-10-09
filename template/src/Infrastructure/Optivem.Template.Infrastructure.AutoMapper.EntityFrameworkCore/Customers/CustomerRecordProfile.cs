using AutoMapper;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;

namespace Optivem.Template.Infrastructure.AutoMapper.EntityFrameworkCore.Customers
{
    public class CustomerRecordProfile : Profile
    {
        public CustomerRecordProfile()
        {
            CreateMap<Customer, CustomerRecord>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(e => e.FirstName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(e => e.FirstName))

                .ConstructUsing(e => new CustomerRecord
                {
                    Id = e.Id.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    OrderRecords = null,
                });

            CreateMap<CustomerIdentity, CustomerRecord>()
                .ConstructUsing(e => new CustomerRecord
                {
                    Id = e.Id,
                });
        }
    }
}
