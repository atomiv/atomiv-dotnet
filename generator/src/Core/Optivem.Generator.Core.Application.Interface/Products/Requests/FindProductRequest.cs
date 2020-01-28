using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Products.Requests
{
    public class FindProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
