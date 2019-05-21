using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class CreateCustomerResponseProfile : ResponseProfile<Customer, CreateCustomerResponse>
    {
    }
}
