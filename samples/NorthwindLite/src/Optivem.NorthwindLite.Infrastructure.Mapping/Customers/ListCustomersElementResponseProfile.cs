using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Mapping
{
    public class ListCustomersElementResponseProfile : ResponseProfile<Customer, ListCustomersElementResponse>
    {
        public ListCustomersElementResponseProfile()
        {
        }
    }
}
