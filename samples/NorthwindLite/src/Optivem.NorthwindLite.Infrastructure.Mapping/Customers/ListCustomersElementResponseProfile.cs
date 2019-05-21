using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Domain.Entities;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class ListCustomersElementResponseProfile : ResponseProfile<Customer, ListCustomersElementResponse>
    {
        public ListCustomersElementResponseProfile()
        {
        }
    }
}
