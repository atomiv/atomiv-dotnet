using Optivem.Atomiv.Core.Application;

namespace Optivem.Generator.Core.Application.Products.Requests
{
    public class RelistProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
