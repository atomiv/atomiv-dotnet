using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Queries.Products;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common.Records;

namespace Optivem.Atomiv.Template.Infrastructure.Queries.Handlers.Products
{
    public class ViewProductQueryHandler : QueryHandler<ViewProductQuery, ViewProductQueryResponse>
    {
        public ViewProductQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewProductQueryResponse> HandleAsync(ViewProductQuery request)
        {
            var productId = request.Id;

            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productId);

            if (productRecord == null)
            {
                throw new ExistenceException();
            }

            return GetFindProductQueryResponse(productRecord);
        }

        private static ViewProductQueryResponse GetFindProductQueryResponse(ProductRecord productRecord)
        {
            return new ViewProductQueryResponse
            {
                Id = productRecord.Id,
                Code = productRecord.ProductCode,
                Description = productRecord.ProductName,
                UnitPrice = productRecord.ListPrice,
                IsListed = productRecord.IsListed,
            };
        }
    }
}