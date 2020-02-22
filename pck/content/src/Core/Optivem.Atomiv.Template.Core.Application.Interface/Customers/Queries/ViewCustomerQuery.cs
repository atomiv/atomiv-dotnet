using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class ViewCustomerQuery : IRequest<ViewCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}