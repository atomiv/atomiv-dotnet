using AutoMapper;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Domain.Customers;

namespace Optivem.Atomiv.Template.Infrastructure.Mapping.Customers
{
    public class UpdateCustomerCommandResponseProfile : Profile
    {
        public UpdateCustomerCommandResponseProfile()
        {
            CreateMap<Customer, UpdateCustomerCommandResponse>();
        }
    }
}
