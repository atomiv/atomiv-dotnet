using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Products;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Products
{
    public class ViewProductQueryHandler : QueryHandler<ViewProductQuery, ViewProductQueryResponse>
    {
        public ViewProductQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewProductQueryResponse> HandleAsync(ViewProductQuery request)
        {
            var productRecordId = request.Id;

            var productRecord = await Context.Products.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == productRecordId);

            if (productRecord == null)
            {
                throw new ExistenceException();
            }

            return GetResponse(productRecord);
        }

        private static ViewProductQueryResponse GetResponse(ProductRecord productRecord)
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