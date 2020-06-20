using Atomiv.Core.Application;

namespace Generator.Core.Application.Products.Requests
{
    public class UnlistProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
