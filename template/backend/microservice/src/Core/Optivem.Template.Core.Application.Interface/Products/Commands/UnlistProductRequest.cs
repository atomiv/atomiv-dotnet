using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class UnlistProductRequest : IRequest<UnlistProductResponse>
    {
        public Guid Id { get; set; }
    }
}