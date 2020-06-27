using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class ViewCustomerQuery : IRequest<ViewCustomerQueryResponse>
    {
        public string Id { get; set; }
    }
}