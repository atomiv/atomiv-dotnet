using Atomiv.Core.Application;

namespace Generator.Core.Application.Products.Responses
{
    public class RelistProductResponse : IResponse<int>
    {
        public int Id { get; set; }
    }
}
