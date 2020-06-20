using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Application.Queries.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Orders
{
    public class FilterOrdersQueryHandler : QueryHandler<FilterOrdersQuery, FilterOrdersQueryResponse>
    {
        public FilterOrdersQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<FilterOrdersQueryResponse> HandleAsync(FilterOrdersQuery request)
        {
            var orderRecords = await Context.Orders.AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync();

            var resultRecords = orderRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await Context.Orders.LongCountAsync();

            return new FilterOrdersQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
        }

        private ListOrdersRecordQueryResponse GetIdNameResult(OrderRecord record)
        {
            var name = record.Id.ToString();

            return new ListOrdersRecordQueryResponse
            {
                Id = record.Id,
                Name = name,
            };
        }
    }
}