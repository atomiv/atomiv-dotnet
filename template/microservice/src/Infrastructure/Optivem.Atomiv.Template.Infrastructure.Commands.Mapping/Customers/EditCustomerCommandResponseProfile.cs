using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Domain.Customers;

namespace Optivem.Atomiv.Template.Infrastructure.Commands.Mapping.Customers
{
    public class EditCustomerCommandResponseProfile : Profile
    {
        public EditCustomerCommandResponseProfile()
        {
            CreateMap<Customer, EditCustomerCommandResponse>();
        }
    }
}
