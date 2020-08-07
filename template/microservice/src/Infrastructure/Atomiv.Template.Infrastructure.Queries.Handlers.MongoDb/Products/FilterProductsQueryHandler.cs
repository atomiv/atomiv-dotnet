using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using System;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDb.Products
{
    public class FilterProductsQueryHandler : QueryHandler<FilterProductsQuery, FilterProductsQueryResponse>
    {
        public FilterProductsQueryHandler(MongoDbContext context) : base(context)
        {
        }

        public override Task<FilterProductsQueryResponse> HandleAsync(FilterProductsQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
