using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Commands.Customers;
using Optivem.Atomiv.Template.Core.Domain.Customers;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Customers
{
    public class CreateCustomerCommandResponseProfile : Profile
    {
        public CreateCustomerCommandResponseProfile()
        {
            CreateMap<Customer, CreateCustomerCommandResponse>();
        }
    }
}
