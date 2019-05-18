using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.BrowseAll;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Queries.List;
using Optivem.NorthwindLite.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Application.UseCases.Customers
{
    public class ListCustomersUseCase : ListUseCase<ListCustomersRequest, ListCustomersResponse, ListCustomersElementResponse, Customer, int>
    {
        public ListCustomersUseCase(IResponseMapper responseMapper, IReadonlyRepository<Customer, int> repository) : base(responseMapper, repository)
        {
        }
    }
}
