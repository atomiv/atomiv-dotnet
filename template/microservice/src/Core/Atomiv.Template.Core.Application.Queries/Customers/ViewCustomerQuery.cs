using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class ViewCustomerQuery : IQuery<ViewCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}