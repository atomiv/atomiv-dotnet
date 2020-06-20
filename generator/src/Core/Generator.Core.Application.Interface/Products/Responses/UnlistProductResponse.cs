using Atomiv.Core.Application;

namespace Generator.Core.Application.Products.Responses
{
    public class UnlistProductResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
