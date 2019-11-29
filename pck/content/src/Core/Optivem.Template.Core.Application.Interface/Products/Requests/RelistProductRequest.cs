using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Products.Responses;
using System;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class RelistProductRequest : IRequest<RelistProductResponse>
    {
        public Guid Id { get; set; }
    }
}