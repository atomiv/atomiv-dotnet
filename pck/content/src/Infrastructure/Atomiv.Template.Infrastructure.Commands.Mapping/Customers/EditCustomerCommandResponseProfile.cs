using AutoMapper;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Domain.Customers;

namespace Atomiv.Template.Infrastructure.Commands.Mapping.Customers
{
    public class EditCustomerCommandResponseProfile : Profile
    {
        public EditCustomerCommandResponseProfile()
        {
            CreateMap<Customer, EditCustomerCommandResponse>();
        }
    }
}
