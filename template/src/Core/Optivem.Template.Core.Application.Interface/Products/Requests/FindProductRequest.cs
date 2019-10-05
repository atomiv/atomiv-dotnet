using Optivem.Framework.Core.Common;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class FindProductRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}
