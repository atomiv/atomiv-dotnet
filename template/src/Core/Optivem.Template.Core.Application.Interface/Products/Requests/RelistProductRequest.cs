using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Products.Responses;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class RelistProductRequest : IRequest<RelistProductResponse, int>
    {
        public int Id { get; set; }
    }
}