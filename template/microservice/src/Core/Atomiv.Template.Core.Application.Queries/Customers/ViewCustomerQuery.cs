using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class ViewCustomerQuery : IRequest<ViewCustomerQueryResponse>
    {
        public string Id { get; set; }
    }
}