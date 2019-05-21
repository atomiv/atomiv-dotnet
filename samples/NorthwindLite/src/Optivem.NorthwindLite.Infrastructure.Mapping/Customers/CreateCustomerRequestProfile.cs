using AutoMapper;
using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class CreateCustomerRequestProfile : RequestProfile<CreateCustomerRequest, Customer>
    {
        protected override void Extend(IMappingExpression<CreateCustomerRequest, Customer> map)
        {
            map.ForMember(e => e.Id, opt => opt.Ignore());
            map.ForMember(e => e.Order, opt => opt.Ignore());
        }
    }
}