using AutoMapper;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.Mapping.Customers
{
    public class CreateCustomerCommandResponseProfile : Profile
    {
        public CreateCustomerCommandResponseProfile()
        {
            CreateMap<Customer, CreateCustomerCommandResponse>();
        }
    }
}
