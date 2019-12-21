using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Products.Responses;
using System;

namespace Optivem.Template.Core.Application.Products.Requests
{
    public class UnlistProductRequest : IRequest<UnlistProductResponse>
    {
        public Guid Id { get; set; }
    }
}