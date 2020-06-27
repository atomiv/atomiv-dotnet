using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Products
{
    public class ViewProductQuery : IRequest<ViewProductQueryResponse>
    {
        public string Id { get; set; }
    }
}