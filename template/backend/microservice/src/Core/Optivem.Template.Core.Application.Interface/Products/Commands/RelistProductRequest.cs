using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class RelistProductRequest : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}