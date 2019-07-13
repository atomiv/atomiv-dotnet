using Optivem.Framework.Core.Application;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class UnlistProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
