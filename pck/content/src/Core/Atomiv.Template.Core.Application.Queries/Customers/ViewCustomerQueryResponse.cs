using System;
using System.Collections.Generic;

namespace Atomiv.Template.Core.Application.Queries.Customers
{
    public class ViewCustomerQueryResponse
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int OpenOrders { get; set; }

        public DateTime? LastOrderDate { get; set; }

        public int TotalOrders { get; set; }

        public decimal TotalOrderValue { get; set; }

        public List<string> TopProducts { get; set; }
    }
}