using Atomiv.Core.Application;

namespace Generator.Core.Application.Products.Requests
{
    public class RelistProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
