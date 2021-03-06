﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.Customers
{
    public class FilterCustomersQueryHandler : QueryHandler<FilterCustomersQuery, FilterCustomersQueryResponse>
    {
        public FilterCustomersQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<FilterCustomersQueryResponse> HandleAsync(FilterCustomersQuery query)
        {
            var nameSearch = query.NameSearch;
            var limit = query.Limit;

            var customerRecords = await Context.Customers.AsNoTracking()
                .Where(e => e.FirstName.Contains(nameSearch) || e.LastName.Contains(nameSearch))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Take(limit)
                .ToListAsync();

            var resultRecords = customerRecords
                .Select(GetResponse)
                .ToList();

            var totalRecords = await Context.Customers.LongCountAsync();

            return new FilterCustomersQueryResponse
            {
                Records = resultRecords,
                TotalRecords = totalRecords,
            };
        }

        private ListCustomersRecordResponse GetResponse(CustomerRecord customerRecord)
        {
            var id = customerRecord.Id;
            var name = $"{customerRecord.FirstName} {customerRecord.LastName}";

            return new ListCustomersRecordResponse
            {
                Id = id,
                Name = name,
            };
        }
    }
}