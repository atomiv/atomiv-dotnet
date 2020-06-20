using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Customers
{
    public class CreateCustomerCommandResponseProfile : Profile
    {
        public CreateCustomerCommandResponseProfile()
        {
            CreateMap<Customer, CreateCustomerCommandResponse>();
        }
    }
}
