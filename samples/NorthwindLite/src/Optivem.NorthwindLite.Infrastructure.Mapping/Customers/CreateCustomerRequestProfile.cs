using AutoMapper;
using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class CreateCustomerRequestProfile : RequestProfile<CreateCustomerRequest, Customer>
    {
        protected override void Extend(IMappingExpression<CreateCustomerRequest, Customer> map)
        {
            map.ConstructUsing(e => new Customer(CustomerIdentity.Null, e.FirstName, e.LastName));
        }
    }
}