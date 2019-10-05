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
                .ConstructUsing(e => new CustomerRecord
                {
                    Id = e.Id.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Order = null,
                });

            CreateMap<CustomerRecord, Customer>()
                .ConstructUsing(e => new Customer(new CustomerIdentity(e.Id), e.FirstName, e.LastName));

            CreateMap<CustomerIdentity, CustomerRecord>()
                .ConstructUsing(e => new CustomerRecord
                {
                    Id = e.Id,
                });
        }
    }
}
