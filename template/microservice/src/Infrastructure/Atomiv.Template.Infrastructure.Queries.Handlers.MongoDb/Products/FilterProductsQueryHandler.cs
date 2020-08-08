using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Products
{
    public class FilterProductsQueryHandler : QueryHandler<FilterProductsQuery, FilterProductsQueryResponse>
    {
        public FilterProductsQueryHandler(MongoDBContext context) : base(context)
        {
        }

        public override Task<FilterProductsQueryResponse> HandleAsync(FilterProductsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
