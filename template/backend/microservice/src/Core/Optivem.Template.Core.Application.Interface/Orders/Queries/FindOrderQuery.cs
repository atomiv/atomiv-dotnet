using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Queries
{
    public class FindOrderQuery : IRequest<FindOrderQueryResponse>
    {
        public Guid Id { get; set; }
    }
}